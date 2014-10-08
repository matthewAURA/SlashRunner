using System.Collections.Generic;

public class InputMap {
	
	//Dictionary Mapping MultiPlatformInputs to function Delegates
	Dictionary<MultiPlatformInputs, List<InputAction>> inputMap = new Dictionary<MultiPlatformInputs, List<InputAction>>();
	
	static InputMap instance;

	public delegate void InputAction();
	
	public static InputMap getInputMap() {
		if (instance == null) {
			instance = new InputMap ();
		}
		return instance;
	}
	
	/**
	 * Maps a given input to a given function so that
	 * when that input is detected the function will be called.
	*/
	public void Add(MultiPlatformInputs input, InputAction function) {
		if (inputMap.ContainsKey (input)) {
			List<InputAction> value = inputMap[input];
			if(!value.Contains(function)) {
				value.Add(function);
				return;
			}
		}
		else {
			List<InputAction> value = new List<InputAction>();
			value.Add(function);
			inputMap.Add (input, value);
		}
	}
	
	/**
	 * Maps a given list of inputs to a given function so that
	 * when that input is detected the function will be called.
	*/
	public void Add(List<MultiPlatformInputs> inputs, InputAction function) {
		foreach(MultiPlatformInputs input in inputs) {
			this.Add(input, function);
		}
	}
	
	/**
	 * Fires all functions that are mapped to the given input.
	*/
	public void FireInputEvents(MultiPlatformInputs input) {
		if (inputMap.ContainsKey (input)) {
			foreach(InputAction function in inputMap[input]) {
				function.DynamicInvoke();
			}
		}
	}
}
