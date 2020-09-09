﻿using System;

using UIKit;
using AVFoundation;
using Foundation;
using System.Diagnostics;
using AudioToolbox;
using System.IO;

namespace Sound
{
	public partial class ViewController : UIViewController
	{
		// declarations
		AVAudioRecorder recorder;
		AVPlayer player;
		NSDictionary settings;
		Stopwatch stopwatch = null;
		NSUrl audioFilePath = null;
		NSObject observer;

		public ViewController (IntPtr handle) : base (handle)
		{
			AudioSession.Initialize ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.RecordingStatusLabel.Text = "";
			this.LengthOfRecordingLabel.Text = "";

			// start recording wireup
			this.StartRecordingButton.TouchUpInside += (sender, e) => {
				Console.WriteLine("Begin Recording");

				AudioSession.Category = AudioSessionCategory.RecordAudio;
				AudioSession.SetActive (true);

				if (!PrepareAudioRecording ()) {
					RecordingStatusLabel.Text = "Error preparing";
					return;
				}

				if (!recorder.Record ()) {
					RecordingStatusLabel.Text = "Error recording";
					return;
				}

				this.stopwatch = new Stopwatch();
				this.stopwatch.Start();
				this.LengthOfRecordingLabel.Text = "";
				this.RecordingStatusLabel.Text = "Recording";
				this.StartRecordingButton.Enabled = false;
				this.StopRecordingButton.Enabled = true;
				this.PlayRecordedSoundButton.Enabled = false;
			};

			// stop recording wireup
			this.StopRecordingButton.TouchUpInside += (sender, e) => {
				this.recorder.Stop();

				this.LengthOfRecordingLabel.Text = string.Format("{0:hh\\:mm\\:ss}", this.stopwatch.Elapsed);
				this.stopwatch.Stop();
				this.RecordingStatusLabel.Text = "";
				this.StartRecordingButton.Enabled = true;
				this.StopRecordingButton.Enabled = false;
				this.PlayRecordedSoundButton.Enabled = true;
			};

			observer = NSNotificationCenter.DefaultCenter.AddObserver (AVPlayerItem.DidPlayToEndTimeNotification, delegate (NSNotification n) {
				player.Dispose ();
				player = null;
			});

			// play recorded sound wireup
			this.PlayRecordedSoundButton.TouchUpInside += (sender, e) => {
				try {
					Console.WriteLine("Playing Back Recording " + this.audioFilePath.ToString());

					// The following line prevents the audio from stopping 
					// when the device autolocks. will also make sure that it plays, even
					// if the device is in mute
					AudioSession.Category = AudioSessionCategory.MediaPlayback;

					this.player = new AVPlayer (this.audioFilePath);
					this.player.Play();
				} catch (Exception ex) {
					Console.WriteLine("There was a problem playing back audio: ");
					Console.WriteLine(ex.Message);
				}
			};
		}

		public override void ViewDidUnload ()
		{
			NSNotificationCenter.DefaultCenter.RemoveObserver (observer);

			base.ViewDidUnload ();

			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;

			ReleaseDesignerOutlets ();
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}

		bool PrepareAudioRecording ()
		{
			// You must initialize an audio session before trying to record
			var audioSession = AVAudioSession.SharedInstance ();
			var err = audioSession.SetCategory (AVAudioSessionCategory.PlayAndRecord);
			if(err != null) {
				Console.WriteLine ("audioSession: {0}", err);
				return false;
			}
			err = audioSession.SetActive (true);
			if(err != null ){
				Console.WriteLine ("audioSession: {0}", err);
				return false;
			}

			// Declare string for application temp path and tack on the file extension
			string fileName = string.Format ("Myfile{0}.aac", DateTime.Now.ToString ("yyyyMMddHHmmss"));
			string tempRecording = Path.Combine (Path.GetTempPath (), fileName);

			Console.WriteLine (tempRecording);
			this.audioFilePath = NSUrl.FromFilename(tempRecording);

			//set up the NSObject Array of values that will be combined with the keys to make the NSDictionary
			NSObject[] values = new NSObject[]
			{    
				NSNumber.FromFloat(44100.0f),
				NSNumber.FromInt32((int)AudioToolbox.AudioFormatType.MPEG4AAC),
				NSNumber.FromInt32(1),
				NSNumber.FromInt32((int)AVAudioQuality.High)
			};
			//Set up the NSObject Array of keys that will be combined with the values to make the NSDictionary
			NSObject[] keys = new NSObject[]
			{
				AVAudioSettings.AVSampleRateKey,
				AVAudioSettings.AVFormatIDKey,
				AVAudioSettings.AVNumberOfChannelsKey,
				AVAudioSettings.AVEncoderAudioQualityKey
			};			
			//Set Settings with the Values and Keys to create the NSDictionary
			settings = NSDictionary.FromObjectsAndKeys (values, keys);

			//Set recorder parameters
			NSError error;
			recorder = AVAudioRecorder.Create(this.audioFilePath, new AudioSettings(settings), out error);
			if ((recorder == null) || (error != null)) {
				Console.WriteLine (error);
				return false;
			}

			//Set Recorder to Prepare To Record
			if (!recorder.PrepareToRecord ()) {
				recorder.Dispose ();
				recorder = null;
				return false;
			}

			recorder.FinishedRecording += delegate (object sender, AVStatusEventArgs e) {
				recorder.Dispose ();
				recorder = null;
				Console.WriteLine ("Done Recording (status: {0})", e.Status);
			};

			return true;
		}
	}
}

