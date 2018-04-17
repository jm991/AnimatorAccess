// The MIT License (MIT)
// 
// Copyright (c) 2014 by SCIO System-Consulting GmbH & Co. KG. All rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;
using System.Collections.Generic;
using Scio.CodeGeneration;
using AnimatorAccess;

namespace Scio.AnimatorAccessGenerator
{
	public enum AnimatorParameterType
	{
		Unknown = -1,
		Int = 0,
		Float = 1,
		Bool = 2,
		Trigger = 3,
	}
	
	/// <summary>
	/// Encapsulates all critical access to UnityEditorInternal stuff. Methods within this class might be affected
	/// by future changes of the Unity API. Thus preprocessor #if statements are expected to grow.
	/// </summary>
	public static class InternalAPIAccess
	{
		public delegate void ProcessAnimatorState (StateInfo info);

		public delegate void ProcessAnimatorTransition (TransitionInfo info);

		public delegate void ProcessAnimatorParameter (AnimatorParameterType t, string item, string defaultValue);

		static UnityEditor.Animations.AnimatorController GetInternalAnimatorController (Animator animator) {
			return animator.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;
		}

		/// <summary>
		/// Adds convenience methods to determine the current Animator state as boolean methods to the class code 
		/// element (e.g. IsIdle ()). NOTE that this method relies on classes from namespace UnityEditorInternal 
		/// which can be subject to changes in future releases.
		/// </summary>
		public static void ProcessAllAnimatorStates (Animator animator, ProcessAnimatorState callback) {
			UnityEditor.Animations.AnimatorController controller = GetInternalAnimatorController (animator);
			int layerCount = controller.layers.Length;
			for (int layer = 0; layer < layerCount; layer++) {
				string layerName = controller.layers[layer].name;
				UnityEditor.Animations.AnimatorStateMachine sm = controller.layers[layer].stateMachine;
				for (int i = 0; i < sm.states.Length; i++) {
					UnityEditor.Animations.AnimatorState state = sm.states[i].state;
					Motion motion = state.motion;
					float duration = (motion != null ? motion.averageDuration : 0f);
					string motionName = (motion != null ? motion.name : "");
					StateInfo info = new StateInfo (state.nameHash, layer, layerName, state.name, state.tag,
						state.speed, state.iKOnFeet, state.mirror, motionName, duration);
					callback (info);
				}
			}
		}

		public static void ProcessAllTransitions (Animator animator, ProcessAnimatorTransition callback) {
			UnityEditor.Animations.AnimatorController controller = GetInternalAnimatorController (animator);
			int layerCount = controller.layers.Length;
			for (int layer = 0; layer < layerCount; layer++) {
				string layerName = controller.layers[layer].name;
				UnityEditor.Animations.AnimatorStateMachine sm = controller.layers[layer].stateMachine;
                		//Handle anyState cases. see UnityEditorInternal.StateMachine.transitions
				{
                    UnityEditor.Animations.AnimatorStateTransition[] anyTransitions = sm.anyStateTransitions;
					foreach (UnityEditor.Animations.AnimatorStateTransition t in anyTransitions) {
						TransitionInfo info = new TransitionInfo (Animator.StringToHash(t.name), t.name, layer, layerName, 
							0, t.destinationState.nameHash, t.hasExitTime, t.duration, t.mute, t.offset, t.solo);
						callback (info);
					}
				}
				for (int i = 0; i < sm.states.Length; i++) {
					UnityEditor.Animations.AnimatorState state = sm.states[i].state;
                    UnityEditor.Animations.AnimatorStateTransition[] transitions = state.transitions;
					foreach (UnityEditor.Animations.AnimatorStateTransition t in transitions) {
						Debug.Log (state.name +  ", transition: " + t.name + " ---" + " dest = " + t.destinationState.name + " (" + (Animator.StringToHash (state.name) == Animator.StringToHash (layerName + "." + t.destinationState.name)) + ") " + " src = " + state.name);
						TransitionInfo info = new TransitionInfo (Animator.StringToHash(t.name), t.name, layer, layerName, 
	                        state.nameHash, t.destinationState.nameHash, t.hasExitTime, t.duration, t.mute, t.offset, t.solo);
						//callback (info);
					}
				}
			}
		}

		/// <summary>
		/// Adds all Animator parameters as properties to the class code element. NOTE that this method relies on 
		/// classes from namespace UnityEditorInternal which can be subject to changes in future releases.
		/// </summary>
		/// <param name="animator">Animator instance to inspect.</param>
		/// <param name="callback">Callback delegate for processing each of the single paramters.</param>
		public static void ProcessAnimatorParameters (Animator animator, ProcessAnimatorParameter callback)
		{
			UnityEditor.Animations.AnimatorController controller = GetInternalAnimatorController (animator);
			int countParameters = controller.parameters.Length;
			if (countParameters > 0) {
				for (int i = 0; i < countParameters; i++) {
                    UnityEngine.AnimatorControllerParameter parameter = controller.parameters[i];
					string item = parameter.name;
					if (parameter.type == UnityEngine.AnimatorControllerParameterType.Bool) {
						callback (AnimatorParameterType.Bool, item, "" + parameter.defaultBool);
					} else if (parameter.type == UnityEngine.AnimatorControllerParameterType.Float) {
						callback (AnimatorParameterType.Float, item, "" + parameter.defaultFloat);
					} else if (parameter.type == UnityEngine.AnimatorControllerParameterType.Int) {
						callback (AnimatorParameterType.Int, item, "" + parameter.defaultInt);
					} else if (parameter.type == UnityEngine.AnimatorControllerParameterType.Trigger) {
						callback (AnimatorParameterType.Trigger, item, "(not available)");
					} else {
						callback (AnimatorParameterType.Unknown, item, null);
					}
				}
			}
		}

	}
}

