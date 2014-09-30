using System.Collections.Generic;

public class InputMap {
	
	//Dictionary Mapping MultiPlatformInputs to function Delegates
	Dictionary<MultiPlatformInputs, List<System.Delegate>> inputMap = new Dictionary<MultiPlatformInputs, List<System.Delegate>>();
	
	static InputMap instance;
	
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
	public void Add(MultiPlatformInputs input, System.Delegate function) {
		if (inputMap.ContainsKey (input)) {
			List<System.Delegate> value = inputMap[input];
			if(!value.Contains(function)) {
				value.Add(function);
				return;
			}
		}
		else {
			List<System.Delegate> value = new List<System.Delegate>();
			value.Add(function);
			inputMap.Add (input, value);
		}
	}
	
	/**
	 * Maps a given list of inputs to a given function so that
	 * when that input is detected the function will be called.
	*/
	public void Add(List<MultiPlatformInputs> inputs, System.Delegate function) {
		foreach(MultiPlatformInputs input in inputs) {
			this.Add(input, function);
		}
	}
	
	/**
	 * Fires all functions that are mapped to the given input.
	*/
	public void FireInputEvents(MultiPlatformInputs input) {
		if (inputMap.ContainsKey (input)) {
			foreach(System.Delegate function in inputMap[input]) {
				function.DynamicInvoke();
			}
		}
	}
}
