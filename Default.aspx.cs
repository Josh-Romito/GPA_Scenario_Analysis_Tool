using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;


public partial class _Default : Page
{

    StreamReader reader = new StreamReader(@"E:\Documents\School_\Y2_S1\CP_380 - ASP.NET\GPA_TOOL_FINAL\Resources\Combinations.txt");
    string line;

    List<int> grades = new List<int> { 0, 1, 2, 3, 4 };

    List<string> classes = new List<string>
    {
        "CP_330", "CP_350", "CP_360",
        "CP_370", "CP_380", "GE", "CP_450",
        "CP_430", "CP_440", "CP_460", "CP_470",
        "CP_480", "CP_490", "CP_340"
    };

    List<TextBox> inputs = new List<TextBox>();
    List<double> comboBaseGrades = new List<double>();
    List<double> percentileGrade = new List<double>();
    List<double> numericLetterGrade = new List<double>();
    List<double> qualityPoints = new List<double>();
    List<double> partialGPA = new List<double>();

    int outstandingCourses;
    double tempGpa = 0;
    double tempPercentage = 50;
    double GPA;
    const int SingleCourseHours = 45;



    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        CollectInput();
        CheckForEmptyCourses();
        AddBasePercentages();
        CalcNumericLetterGrade();
        CalcQualityPoints();
        CalcPartialGPA();
        CalcGPA();

        CalcMinPrecentForGraduation();

    }


    
    protected void Button2_Click(object sender, EventArgs e)
    {
        CollectInput();
        CollectComboInput();
        CalcComboLetterGrade();
        CalcPossibleGradeCombinations();
    }


    private void CalcMinPrecentForGraduation()
    {
        while (tempGpa < 1.99)
        {
            ResetLists();

            if (percentileGrade.Count < 27)
            {
                for (int i = 0; i < outstandingCourses; i++)
                {
                    percentileGrade.Add(tempPercentage);
                }
            }

            for (int i = percentileGrade.Count; i > percentileGrade.Count - outstandingCourses; i--)
            {
                percentileGrade[(i - 1)] = tempPercentage;
                ResetLists();
                CalcNumericLetterGrade();
                CalcQualityPoints();
                CalcPartialGPA();
                tempGpa = CalcGPA();

                if (tempGpa >= 1.99)
                {
                    break;
                }
            }


            tempPercentage++;
        }
        minOutput.InnerHtml += "<h3>In order to graduate with a GPA of: " + tempGpa.ToString("0.00") + "</h3>";
        minOutput.InnerHtml += "<p>You must achieve the following precentages: </p>";

        DisplayMinimumGrades();
    }

    int counter = 0;

    private void CalcPossibleGradeCombinations()
    {
        comboOutput.InnerHtml = "<h3>Grade combination scenarios possible: </h3><br /><hr />";
        while ((line = reader.ReadLine()) != null)
        {
            
            string[] combination = line.Split(',');
            foreach (string i in combination)
            {
                switch (i)
                {
                    case "a":
                        numericLetterGrade.Add(4);
                        break;
                    case "b":
                        numericLetterGrade.Add(3);
                        break;
                    case "c":
                        numericLetterGrade.Add(2);
                        break;
                    case "d":
                        numericLetterGrade.Add(1);
                        break;
                }
            }

            CalcQualityPoints();
            CalcPartialGPA();
            tempGpa = CalcGPA();

            if (tempGpa > 1.99 && tempGpa <= 4.00)
            {
                counter++;
                comboOutput.InnerHtml += "<h3>In order to acheive a GPA of: </h3>" + tempGpa.ToString("0.000") + "<br />";
                comboOutput.InnerHtml += "<p>You must achieve the following second year grades: </p>";
                foreach (double i in numericLetterGrade)
                {
                    if (i == 0)
                    {
                        comboOutput.InnerHtml += "F-";
                    }
                    else if (i == 1)
                    {
                        comboOutput.InnerHtml += "D-";
                    }
                    else if (i == 2)
                    {
                        comboOutput.InnerHtml += "C-";
                    }
                    else if (i == 3)
                    {
                        comboOutput.InnerHtml += "B-";
                    }
                    else if (i == 4)
                    {
                        comboOutput.InnerHtml += "A-";
                    }
                }
                comboOutput.InnerHtml += "<br />";
            }

            ResetLists();
            CalcComboLetterGrade();
        }

        comboOutput.InnerHtml += counter;
    }






    private void DisplayResults()
    {
        minOutput.InnerHtml = GPA.ToString();
    }

    private void CollectInput()
    {
        inputs.Add(TextBox1);
        inputs.Add(TextBox2);
        inputs.Add(TextBox3);
        inputs.Add(TextBox4);
        inputs.Add(TextBox5);
        inputs.Add(TextBox6);
        inputs.Add(TextBox7);
        inputs.Add(TextBox8);
        inputs.Add(TextBox9);
        inputs.Add(TextBox10);
        inputs.Add(TextBox11);
        inputs.Add(TextBox12);
        inputs.Add(TextBox13);
        inputs.Add(TextBox14);
    }

    private void ResetLists()
    {
        numericLetterGrade.Clear();
        partialGPA.Clear();
        qualityPoints.Clear();
        GPA = 0;
    }

    
    private void DisplayMinimumGrades()
    {
        minOutput.InnerHtml += "------------------------------------<br />";

        for (int i = 0;  i < percentileGrade.Count; i++)
        {
            minOutput.InnerHtml +=  percentileGrade[i].ToString() + "%  <br />";
        }

        minOutput.InnerHtml += "------------------------------------";
    }


    private double CalcGPA()
    {
        foreach (double i in partialGPA)
        {
            GPA += i;
        }
        return GPA;
    }


    private void CalcPartialGPA()
    {
        double totalCourseHours = numericLetterGrade.Count * SingleCourseHours;
        foreach (double i in qualityPoints)
        {
            partialGPA.Add(i / totalCourseHours);
        }
    }


    private void CalcQualityPoints()
    {
        foreach (double i in numericLetterGrade)
        {
            qualityPoints.Add(i * SingleCourseHours);
        }
    }


    private void CalcNumericLetterGrade()
    {
        foreach (double i in percentileGrade)
        {
            if (i < 50)
            {
                numericLetterGrade.Add(0);
            }
            else if (i >= 50 && i <= 59.9)
            {
                numericLetterGrade.Add(1);
            }
            else if (i >= 60 && i <= 69.9)
            {
                numericLetterGrade.Add(2);
            }
            else if (i >= 70 && i <= 79.9)
            {
                numericLetterGrade.Add(3);
            }
            else if (i >= 80 && i <= 100)
            {
                numericLetterGrade.Add(4);
            }
        }
    }



    private void CheckForEmptyCourses()
    {
        foreach (TextBox t in inputs)
        {
            if (t.Text == String.Empty || t.Text == null)
            {
                outstandingCourses++;
            }
            else
            {
                percentileGrade.Add(double.Parse(t.Text));
            }
        }
    }

    private void AddBasePercentages()
    {
        for(int i = 0; i < 13; i++)
        {
            outstandingCourses++;
        }
    }



    private void CalcComboLetterGrade()
    {
        foreach (double i in comboBaseGrades)
        {
            if (i < 50)
            {
                numericLetterGrade.Add(0);
            }
            else if (i >= 50 && i <= 59.9)
            {
                numericLetterGrade.Add(1);
            }
            else if (i >= 60 && i <= 69.9)
            {
                numericLetterGrade.Add(2);
            }
            else if (i >= 70 && i <= 79.9)
            {
                numericLetterGrade.Add(3);
            }
            else if (i >= 80 && i <= 100)
            {
                numericLetterGrade.Add(4);
            }
        }
    }
    private void CollectComboInput()
    {
        foreach(TextBox t in inputs)
        {

            if (t.Text == String.Empty || t.Text == null)
            {
                comboBaseGrades.Add(49);
            }
            else
            {
                comboBaseGrades.Add(double.Parse(t.Text));
            }
        }
    }
}