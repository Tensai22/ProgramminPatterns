using Practice8.Command;
using Practice8.Mediator;
using Practice8.TemplateMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Command
            RemoteControl remote = new RemoteControl();

            Light livingRoomLight = new Light();
            AirConditioner airConditioner = new AirConditioner();

            ICommand lightOn = new LightOnCommand(livingRoomLight);
            ICommand lightOff = new LightOffCommand(livingRoomLight);

            ICommand acOn = new AirConditionerOnCommand(airConditioner);
            ICommand acOff = new AirConditionerOffCommand(airConditioner);

            remote.SetCommand(0, lightOn, lightOff);
            remote.SetCommand(1, acOn, acOff);

            remote.OnButtonPressed(0);
            remote.OffButtonPressed(0);
            remote.OnButtonPressed(1);
            remote.UndoButtonPressed();

            List<ICommand> morningCommands = new List<ICommand> { lightOn, acOn };
            ICommand morningRoutine = new MacroCommand(morningCommands);
            morningRoutine.Execute();
            morningRoutine.Undo();
            //TemplateMethod
            ReportGenerator pdfReport = new PdfReport();
            pdfReport.GenerateReport();

            ReportGenerator excelReport = new ExcelReport();
            excelReport.GenerateReport();

            ReportGenerator htmlReport = new HtmlReport();
            htmlReport.GenerateReport();
            //Mediator
            IMediator mediator = new ChatMediator();

            User user1 = new ConcreteUser(mediator, "Bagybek");
            User user2 = new ConcreteUser(mediator, "Aisyn");
            User user3 = new ConcreteUser(mediator, "Alinur");

            mediator.RegisterUser(user1);
            mediator.RegisterUser(user2);
            mediator.RegisterUser(user3);

            user1.Send("Assalaymagaleikum");
            user2.Send("Yaleikum assalam");
            user3.Send("Che tam?");
        }
    }
}
