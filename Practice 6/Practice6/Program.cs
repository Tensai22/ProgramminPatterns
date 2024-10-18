using Practice6.Builder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger logger = Logger.GetInstance();
            logger.SetLevel(LogLevel.Warning);
            logger.Log("Some error", LogLevel.Warning);

            IPizzaBuilder margarita = new Margaritta();
            PizzaDirecter directer = new PizzaDirecter(margarita);

            directer.ConstructPizza();
            var pizza = directer.GetPizza();

            IReportBuilder textBuilder = new TextReportBuilder();
            ReportDirector director = new ReportDirector();
            ReportStyle textStyle = new ReportStyle("White", "Black", 12);
            director.ConstructReport(textBuilder, textStyle);
            Report textReport = textBuilder.GetReport();
            Console.WriteLine(textReport.Export());
            IReportBuilder htmlBuilder = new HtmlReportBuilder();
            ReportStyle htmlStyle = new ReportStyle("White", "Black", 14);
            director.ConstructReport(htmlBuilder, htmlStyle);
            Report htmlReport = htmlBuilder.GetReport();
            System.Console.WriteLine(htmlReport.Export());

            PdfReportBuilder pdfBuilder = new PdfReportBuilder();
            ReportStyle pdfStyle = new ReportStyle("White", "Black", 16);
            director.ConstructReport(pdfBuilder, pdfStyle);
            Report pdfReport = pdfBuilder.GetReport();
            pdfBuilder.ExportToPdf("report.pdf");
            System.Console.WriteLine("\nPDF Report: report.pdf");
            JsonReportBuilder jsonBuilder = new JsonReportBuilder();
            ReportStyle jsonStyle = new ReportStyle("White", "Black", 14);
            director.ConstructReport(jsonBuilder, jsonStyle);
            jsonBuilder.ExportToJson("report.json");
            Console.WriteLine("JSON report created: report.json");


            GameWeapon axe = new GameWeapon("Axe", 60);
            GameArmor plateArmor = new GameArmor("Plate Armor", 50);
            List<GameSkill> characterSkills = new List<GameSkill>
        {
            new GameSkill("Lightning Strike", "Magic"),
            new GameSkill("Shield Bash", "Physical")
        };

            GameCharacter originalCharacter = new GameCharacter("Paladin", 120, 25, 12, 8, axe, plateArmor, characterSkills);

            GameCharacter clonedCharacter = originalCharacter.Clone();

            clonedCharacter.CharacterName = "Sorcerer";
            clonedCharacter.EquippedWeapon.WeaponName = "Magic Staff";
            clonedCharacter.SkillsList[0].SkillName = "Frostbolt";

            Console.WriteLine("Original Character:");
            Console.WriteLine(originalCharacter);
            Console.WriteLine("\nCloned Character:");
            Console.WriteLine(clonedCharacter);
        }
    }
}
