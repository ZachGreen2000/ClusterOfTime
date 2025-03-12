using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayAndNightCycle : MonoBehaviour
{
    public const float SecondsInDay = 86400f;

    [SerializeField][Range(0, SecondsInDay)] private float realtimeDayLength = 60;
    [SerializeField] private float startHour;

    private DateTime currentTime;
    private DateTime lastDayTime;
    private int startTime = 7;
    private int timeOfDay; 

    private int currentDay = 1;
    private int currentWeek = 1;
    private int currentMonth = 1;
    private int currentYear = 1;
    private int currentDayofMonth = 1;

    private string DayOfWeek;
    private string MonthOfYear;
    private string DayOfMonth;


    public TMP_Text Calendar; // Reference to the Text object
    public TMP_Text Clock;

    private void TimeUpdate()
    {
        // Calculate a seconds step that we need to add to the current time
        float secondsStep = SecondsInDay / realtimeDayLength * Time.deltaTime;
        currentTime = currentTime.AddSeconds(secondsStep);


        // Check and increment the days passed
        TimeSpan difference = currentTime - lastDayTime;

        if (difference.TotalSeconds >= SecondsInDay)
        {
            lastDayTime = currentTime;
            timeOfDay ++; 
        }
        if (timeOfDay >= 24)
        {
            timeOfDay = startTime;
            currentDay++;
            currentDayofMonth++;
        }
        if (currentDay == 8) // After 7 days, increases week count, sets days to 1
        {
            currentWeek++;
            currentDay = 1;
        }
        if (currentDayofMonth == 29)
        {
            if (currentMonth == 2 && currentYear != 4)
            {
                currentDayofMonth = 1;
                currentMonth++;
            }
        }
        if (currentDayofMonth == 30)
        {
            if (currentMonth == 2 && currentYear == 4)
            {
                currentDayofMonth = 1;
                currentMonth++;
            }
        }
        if (currentDayofMonth == 31)
        {
            if (currentMonth == 4 || currentMonth == 6 || currentMonth == 9 || currentMonth == 11)
            {
                currentDayofMonth = 1;
                currentMonth++;
            }
        }
        if (currentDayofMonth == 32)
        {
            if (currentMonth == 1 || currentMonth == 3 || currentMonth == 5 || currentMonth == 7 || currentMonth == 8 || currentMonth == 10 || currentMonth == 12)
            {
                currentDayofMonth = 1;
                currentMonth++;
            }
        }

        if (currentMonth == 13) // After 12 months, increases year count, sets month to 1
        {
            currentYear++;
            currentMonth = 1;
        }
        Clock.text = timeOfDay.ToString();
    }
    private void DayCycle() // Sets integer value to a String day of the week
    {
        switch ((int)currentDay)
        {
            case 1:
                DayOfWeek = "Monday "; break;
            case 2:
                DayOfWeek = "Tuesday "; break;
            case 3:
                DayOfWeek = "Wednesday "; break;
            case 4:
                DayOfWeek = "Thursday "; break;
            case 5:
                DayOfWeek = "Friday "; break;
            case 6:
                DayOfWeek = "Saturday "; break;
            case 7:
                DayOfWeek = "Sunday "; break;
        }
    }
    private void DoMCycle()
    {
        if (currentDayofMonth == 1 || currentDayofMonth == 21 || currentDayofMonth == 31)
        {
            DayOfMonth = currentDayofMonth + "st ";
        }
        else if (currentDayofMonth == 2 || currentDayofMonth == 22)
        {
            DayOfMonth = currentDayofMonth + "nd ";
        }
        else if (currentDayofMonth == 3 || currentDayofMonth == 23)
        {
            DayOfMonth = currentDayofMonth + "rd ";
        }
        else
        {
            DayOfMonth = currentDayofMonth + "th ";
        }
    }

    private void MonthCycle() // Sets integer value to a String month of the year
    {
        switch ((int)currentMonth)
        {
            case 1:
                MonthOfYear = "January"; break;
            case 2:
                MonthOfYear = "February"; break;
            case 3:
                MonthOfYear = "March"; break;
            case 4:
                MonthOfYear = "April"; break;
            case 5:
                MonthOfYear = "May"; break;
            case 6:
                MonthOfYear = "June"; break;
            case 7:
                MonthOfYear = "July"; break;
            case 8:
                MonthOfYear = "August"; break;
            case 9:
                MonthOfYear = "September"; break;
            case 10:
                MonthOfYear = "October"; break;
            case 11:
                MonthOfYear = "November"; break;
            case 12:
                MonthOfYear = "December"; break;
        }
    }


    private void Start()
    {
        currentTime = DateTime.Now + TimeSpan.FromHours(startHour);
        lastDayTime = currentTime;
        timeOfDay = startTime;

        if (Calendar == null)
        {
            Calendar = GameObject.Find("Calendar").GetComponent<TMP_Text>();
        }
        // Display the current date on the TextMeshPro object
        Date();
    }
    private void Date()
    {
        string date = DayOfWeek + DayOfMonth + MonthOfYear.ToString();

        Calendar.text = date;
    }
    private void Update()
    {
        TimeUpdate(); // Runs Timer
        DayCycle();  // Sets Day to String Value
        MonthCycle(); // Sets Month to String Value
        DoMCycle();
        Date();
        //Debug.Log("Day: " + DayOfWeek);

        //Debug.Log(date);
    }
}
