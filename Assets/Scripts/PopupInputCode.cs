using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupInputCode : BasePopup {
	public PopupCodeError popupCodeError;
	public InputField inputFieldCode;

	[Space (15f)]
	public int maxLength = 8;
	public string[] codes;
	bool error = true;

	public override void Show ()
	{
		error = true;
		base.Show ();
	}

//	void OnEnable()
//	{
//		inputFieldCode.onValidateInput += delegate(string text, int charIndex, char addedChar) {
//			return validatedChar(addedChar);
//		};
//	}
//	void OnDisable()
//	{
//		inputFieldCode.onValidateInput -= delegate(string text, int charIndex, char addedChar) {
//			return validatedChar(addedChar);
//		};
//	}

	public void ButtonSubmitOnClick()
	{
		ValidateCode();
	}

	public void ButtonCancelOnClick()
	{
		Hide();
	}

//	char validatedChar(char charToValidate)
//	{
//		string temp = charToValidate.ToString().ToUpper();
//		return temp[0];
//	}

	void ValidateCode()
	{
		print("Code Length = "+inputFieldCode.text.Length);
		if(inputFieldCode.text.Length < maxLength){
			popupCodeError.Show(ErrorCode.WrongCode );
			return;
		}


		string tempCode = inputFieldCode.text.ToUpper();
		print("Code = "+tempCode);
		for(int i = 0;i<codes.Length;i++){
			print(i+": "+tempCode.CompareTo(codes[i]));
			if(tempCode.CompareTo(codes[i]) == 0){
				error = false;
				break;
			}
		}

		popupCodeError.Show( error ? ErrorCode.WrongCode : ErrorCode.Success);
	}
}
