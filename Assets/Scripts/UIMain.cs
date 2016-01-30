using UnityEngine;
using UnityEngine.UI;

//attached to main Canvas
public class UIMain : MonoBehaviour
{
	[SerializeField]
	private civilian_manager civilianManager;

    [SerializeField]
    private Canvas optionsMenuCanvas;
    [SerializeField]
    private Button[] optionButtons;
    [SerializeField]
    private Text[] optionButtonsText;
    [SerializeField]
    private Text[] optionButtonsCost;
    [SerializeField]
    private Text discription;

	private int severity;

    [SerializeField]
    private Canvas outcomeCanvas;
    [SerializeField]
    private Text outcome;

    [SerializeField]
    private Canvas sacMenuCanvas;
    [SerializeField]
    private InputField numberInput;
    private int limit;

    enum State { Sac, Options, Outcome, None };
    private State currentState = State.None;

	void Start(){
		//UIMain.NewSac (10);
	}

    private static UIMain singleton;
    void Awake()
    {
        singleton = this;
    }

    //Called by gamelogic
    #region
	public static void NewEvent (string discription, string[] options, int[] cost, int severity)
    {
		singleton.NewEventP(discription,options,cost,severity);
    }

    public static void NewOutcome(string outcome)
    {
        singleton.NewOutcomeP(outcome);
    }

    public static void NewSac(int limit)
    {
        singleton.NewSacP(limit);
    }
    #endregion

    //Need to trigger gamelogic
    #region
    //Called by buttons/inputfield
    public void SelectedOption(int index)
    {
        //output int of index of option
		Debug.Log ("OptionSelected");
		NewOutcome ("Selected button :" + index);
		if (severity == 0) {
			//nutralEvent
		} else if (severity > 0) {
			//bad event
			MainEngine.singleton.BadEventEnd (index,severity);
		} else {
			//good event
			MainEngine.singleton.GoodEventEnd (index,severity * -1);
		}
    }

    public void SacConfirmed()
    {
        if(numberInput.text.Length > 0)
        {
			MainEngine.NewSacrificeMade(Mathf.Clamp(int.Parse(numberInput.text), 1, limit));
        }
        //output number chosen (fromInput field)
    }

    public void OutcomeOKed()
    {
        //when user clicks OK after seeing result of event
    }
    #endregion

    public void InputFieldUpdated()
    {
        if (numberInput.text.Length > 0)
        {
            int value = Mathf.Clamp(int.Parse(numberInput.text), 1, limit);
            numberInput.text = value.ToString();
        }
    }

    public void SacInputIncrease()
    {
        if (numberInput.text.Length > 0)
        {
            int value = Mathf.Clamp(int.Parse(numberInput.text) + 1, 1, limit);
            numberInput.text = value.ToString();
        }
    }

    public void SacInputDecreased()
    {
        if (numberInput.text.Length > 0)
        {
            int value = Mathf.Clamp(int.Parse(numberInput.text) - 1, 1, limit);
            numberInput.text = value.ToString();
        }
    }

	private void NewEventP(string discriptionText, string[] options, int[] optionCost, int severity)
    {
		this.severity = severity;
        //string discriptionText = "DiscriptionText";
        //string[] options = { "Option 1", "Option 2", "Option 3", "Option 4" };
        //int[] optionCost = { 5, 10, 20, 30 };

        currentState = State.Options;
        DisableCanvases();
        optionsMenuCanvas.enabled = true;

        discription.text = discriptionText;
        for (int i = 0; i < optionButtonsText.Length; i++)
        {
            if (i < options.Length)
            {
                OptionButtonEnabled(i, true);

                optionButtonsText[i].text = options[i];
                optionButtonsCost[i].text = "" + optionCost[i];
            }
            else
            {
                //deactivate extra button
                OptionButtonEnabled(i, false);
            }
        }

    }

    private void DisableCanvases()
    {
        optionsMenuCanvas.enabled = false;
        sacMenuCanvas.enabled = false;
        outcomeCanvas.enabled = false;
    }

    private void OptionButtonEnabled(int i, bool toEnable)
    {
        optionButtons[i].interactable = toEnable;
        optionButtons[i].GetComponent<Image>().enabled = toEnable;
        optionButtonsCost[i].enabled = toEnable;
        optionButtonsText[i].enabled = toEnable;
    }

    private void NewOutcomeP(string text)
    {
        currentState = State.Outcome;
        outcome.text = text;
        DisableCanvases();
        outcomeCanvas.enabled = true;
		optionsMenuCanvas.enabled = true;
		
		civilianManager.Calm();
    }

    private void NewSacP(int limit)
    {
		if (numberInput.text.Length > 0) {
			numberInput.text = "1";
		}
        currentState = State.Sac;
        DisableCanvases();
        sacMenuCanvas.enabled = true;
        this.limit = limit;
    }
}
