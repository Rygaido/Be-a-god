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
		UIMain.NewOutcome ("anything");
	}

    private static UIMain singleton;
    void Awake()
    {
        singleton = this;
    }

    //Called by gamelogic
    #region
    public static void NewEvent(/*Event info*/)
    {
        singleton.NewEventP();
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
    }

    public void SacConfirmed()
    {
        if(numberInput.text.Length > 0)
        {

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
            int value = Mathf.Clamp(int.Parse(numberInput.text), 0, limit);
            numberInput.text = value.ToString();
        }
    }

    public void SacInputIncrease()
    {
        if (numberInput.text.Length > 0)
        {
            int value = Mathf.Clamp(int.Parse(numberInput.text) + 1, 0, limit);
            numberInput.text = value.ToString();
        }
    }

    public void SacInputDecreased()
    {
        if (numberInput.text.Length > 0)
        {
            int value = Mathf.Clamp(int.Parse(numberInput.text) - 1, 0, limit);
            numberInput.text = value.ToString();
        }
    }

    private void NewEventP()
    {
        string discriptionText = "DiscriptionText";
        string[] options = { "Option 1", "Option 2", "Option 3", "Option 4" };
        int[] optionCost = { 5, 10, 20, 30 };

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
        currentState = State.Sac;
        DisableCanvases();
        sacMenuCanvas.enabled = true;
        this.limit = limit;
    }
}
