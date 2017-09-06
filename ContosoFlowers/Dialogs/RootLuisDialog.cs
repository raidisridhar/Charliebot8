namespace LuisBot.Dialogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Builder.FormFlow;
    using Microsoft.Bot.Builder.Luis;
    using Microsoft.Bot.Builder.Luis.Models;
    using Microsoft.Bot.Connector;
    using ContosoFlowers.Properties;
    using ContosoFlowers.BotAssets.Extensions;

    [LuisModel("87001b9b-2bb7-461f-af7e-3dc08032f9e4", "9660d9c0c855475eace4e50e5e69d61c")]
    [Serializable]
    public class RootLuisDialog : LuisDialog<object>
    {
        private const string EntityGeographyCity = "builtin.geography.city";

        private const string EntityHotelName = "Hotel";

        private const string EntityAirportCode = "AirportCode";

        private const string EntityClinicalTrail = "Clinical trail";

        private const string EntityCancer = "Cancer";

        private const string EntityTest = "Test";
        
        private IList<string> titleOptions = new List<string> { "“EGFR”", "“JAK2”", "“KRAS”", "“BRAF”", "“NRAS”", "“Tumor percent”" };

        private string chattername = "";
        private string priorintent = "";
        

        [LuisIntent("Checklist")]
        public async Task Checklist(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            await context.PostAsync("These are the tasks for visit 2");
            await context.PostAsync("Take vitals and temperature");
            await context.PostAsync("Grade the disease");
            await context.PostAsync("Etc...");
            priorintent = "Checklist";
            context.Wait(this.MessageReceived);

            
        }

        [LuisIntent("Trial")]
        public async Task Trial(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("The trial end points are...");
            await context.PostAsync("Disease free survival");
            await context.PostAsync("Decrease in tumor percent");
            await context.PostAsync("Normal function of body vitals");
            priorintent = "Trial";
            context.Wait(this.MessageReceived);

            
        }
        [LuisIntent("Gleasonscore")]
        public async Task Gleasonscore(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("A system of grading prostate cancer tissue based on how it looks under a microscope. Gleason scores range from 2 to 10 and indicate how likely it is that a tumor will spread. A low Gleason score means the cancer tissue is similar to normal prostate tissue and the tumor is less likely to spread; a high Gleason score means the cancer tissue is very different from normal and the tumor is more likely to spread.");

            priorintent = "Gleasonscore";
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("EGFR")]
        public async Task EGFR(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("The estimated glomerular filtration rate (eGFR) is used to screen for and detect early kidney damage, to help diagnose chronic kidney disease (CKD), and to monitor kidney status");

            priorintent = "EGFR";
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Mammaprint")]
        public async Task Mammaprint(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("MammaPrint test is a genomic test that analyzes the activity of certain genes in early-stage breast cancer. Research suggests the MammaPrint test may eventually be widely used to help make treatment decisions based on the cancer's risk of coming back (recurrence) within 10 years after diagnosis.");
            priorintent = "Mammaprint";
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Cancerstaging")]
        public async Task Cancerstaging(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Cancer staging is the process of determining how much cancer is in the body and where it is located. Staging describes the severity of an individual's cancer based on the magnitude of the original (primary) tumor as well as on the extent cancer has spread in the body.");
            priorintent = "Cancerstaging";
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("ReportedOutcome")]
        public async Task ReportedOutcome(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("It is SF 36");
            priorintent = "ReportedOutcome";
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Upload")]
        public async Task Upload(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("You can upload it into EDC once you enter the data or you can share it through secured network online.");
            priorintent = "Upload";
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Adverseevent")]
        [LuisIntent("Advers")]
        public async Task Adverseevent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Did you review the Adverse Events Instructions manual and whom to report?");
            priorintent = "Adverseevent";
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("AEevent")]
        public async Task AEevent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Is it Critical?");
            priorintent = "AEevent";
            context.Wait(this.MessageReceived);
        }


        [LuisIntent("Subjectquestion")]
        public async Task Subjectquestion(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Is there any AE Number assigned?");
            priorintent = "Subjectquestion";
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Procedure")]
        public async Task Procedure(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Let me check....");
            await context.PostAsync("I'll connect to CRA.");
            await context.PostAsync("Inbetween please refer to Protocol Template under section 5 where the Procedure details are outlined.");
            await context.PostAsync("Please wait.....");
            priorintent = "Procedure";
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Schedule")]
        public async Task Schedule(IDialogContext context, LuisResult result)
        {
            if (priorintent == "AEevent")
            {
                await context.PostAsync("If yes please fill in complimentary page for SAE and report to Pharmacovigilance immediately");
                await context.PostAsync("Results in Death?");
                await context.PostAsync("Is Life threatening?");
                await context.PostAsync("Requires or prolongs hospitalization?");
                await context.PostAsync("Congenital anomaly or birth defect?");
                await context.PostAsync("Persistent or significant disability/incapacity?");
                priorintent = "AEevent";
                context.Wait(this.MessageReceived);
            }
            else
            {
                await context.PostAsync("Great!!! ");
                await context.PostAsync("Do we have any Lab reports or EKG for Patient 1240");
                priorintent = "Schedule";
                context.Wait(this.MessageReceived);
            }
        }

        [LuisIntent("consentform")]
        public async Task consent(IDialogContext context, LuisResult result)
        {
          
            await context.PostAsync("Do you need assistance on consent form?");
            priorintent = "consentform";
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Diagnosed")]
        public async Task Diagnosed(IDialogContext context, LuisResult result)
        {
            if (priorintent == "Checkhistory")
            {
                await context.PostAsync("Let me check, can you hold for a second……");
                priorintent = "Diagnosisissue";
                context.Wait(this.MessageReceived);
            }
            else
            {
                await context.PostAsync("Sorry to hear that, how can I help you?");
                priorintent = "Diagnosed";
                context.Wait(this.MessageReceived);
            }
        }

        
        [LuisIntent("Diagnosisissue")]
        public async Task Diagnosisissue(IDialogContext context, LuisResult result)
        {

            await context.PostAsync("Let me check, can you hold for a second……");
            priorintent = "Diagnosisissue";
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Participate")]
        public async Task Participate(IDialogContext context, LuisResult result)
        {
           
            await this.ParticipationAsync(context, "Good question. Let me check the criteria and is there any roll over study for this trial. See if this information helps.");
            
            priorintent = "Participate";
        }

        [LuisIntent("Help")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            string message = result.Query.ToUpper();

            string mystr = message.Substring(0, 3);

            if (mystr == "YES")
            {
                
                await context.PostAsync("Great!! Do you have any other questions...");
                context.Wait(this.MessageReceived);
            }
            else
            {
                await context.PostAsync("Hmm, sorry may be I didnt get your question correctly. Can you please rephrase your question for me.");
                context.Wait(this.MessageReceived);
            }
            priorintent = "Help";
        }

        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            string message = result.Query.ToUpper();
            string message2 = result.Query;
            string mystr = "";
            if (message.Length > 2)
            { 
                mystr = message.Substring(0, 3);
            }
            else
            {
                mystr = message;
            }

            if (mystr == "YES")
            {
                await context.PostAsync("Great!! Do you have any other questions...");
                context.Wait(this.MessageReceived);
            }
            else
            {
                if (message.Contains("THIS"))
                {
                    var res = message2.Substring(message2.LastIndexOf(' ') + 1);
                    char[] a = res.ToCharArray();
                    a[0] = char.ToUpper(a[0]);
                    res = new string(a);
                    await context.PostAsync("Hi " + res + ", how may I help you today? How are you?.");
                    chattername = res;
                }
                else
                {
                    await context.PostAsync("Hi, how may I help you today? How are you?.");
                }
                context.Wait(this.MessageReceived);
                // await this.StartOverAsync(context, Resources.RootDialog_Greeting);
            }

            // context.Wait(this.MessageReceived);
            priorintent = "Greeting";

        }

        [LuisIntent("Updatedform")]
        public async Task Updatedform(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Yes " + chattername + ", it is under Sponsor (consent form Document).");
            priorintent = "Updatedform";
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Question")]
        public async Task Question(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I'll be happy to help you. What was your question?");
            priorintent = "Question";
            context.Wait(this.MessageReceived);
        }


        [LuisIntent("Sure")]
        [LuisIntent("Thanks")]
        public async Task Sure(IDialogContext context, LuisResult result)
        {
            if (priorintent == "AEevent")
            {
                await context.PostAsync("If yes please fill in complimentary page for SAE and report to Pharmacovigilance immediately");
                await context.PostAsync("Results in Death?");
                await context.PostAsync("Is Life threatening?");
                await context.PostAsync("Requires or prolongs hospitalization?");
                await context.PostAsync("Congenital anomaly or birth defect?");
                await context.PostAsync("Persistent or significant disability/incapacity?");
                priorintent = "Sure";
                context.Wait(this.MessageReceived);
            }
            else
            {
                await context.PostAsync("is there anything else I can help you with?");
                priorintent = "Sure";   
                context.Wait(this.MessageReceived);
            }
        }

        [LuisIntent("Duration")]
        public async Task Duration(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("3 months");
            await context.PostAsync("Again all this information is available within Protocol Template under Sponsor for reference.");
            
            priorintent = "Duration";
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Enterlabresults")]
        public async Task Enterlabresults(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("you can share it through secured or upload into EDC");
            await context.PostAsync("Do you have access to EDC system? If so you can enter the data into the EDC system.");

            priorintent = "Enterlabresults";
            context.Wait(this.MessageReceived);
        }


        [LuisIntent("Exclusioncriteria")]
        public async Task Exclusion(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("From Section 5 and Section 6.1 within Protocol Template it is outlined the exclusion and inclusion criteria and Intervention administration procedures.");
            await context.PostAsync("For age>18 inclusion and <18 exclusion depending on the participants who require screening…");
            await context.PostAsync("Screening procedures will be performed under a separate screening consent form…");

            priorintent = "Exclusioncriteria";
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Intervention")]
        public async Task Intervention(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I will be glad to answer; before answering did you check the Protocol document of synopsis where it has study phase and what kind of Biologic study interventions.");
            priorintent = "Intervention";
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Checkhistory")]
        public async Task Checkhistory(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Depending on the Severity, you can follow the AE guidelines document and report the event immediately to local authorities.");
            priorintent = "Checkhistory";
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Negativeresponse")]
        public async Task Negativeresponse(IDialogContext context, LuisResult result)
        {
            if (priorintent == "Intervention")
            {
                await context.PostAsync("Let me answer it is Phase II a Study for Corneal Toxicity, but I strongly recommend you to go through the protocol document.");

                context.Wait(this.MessageReceived);
            }
            else
            {
                await context.PostAsync("Sorry about that. How can I help you.");
                // no need priorintent = "Negativeresponse";
                context.Wait(this.MessageReceived);
            }
        }


        [LuisIntent("Informationsheet")]
        public async Task Informationsheet(IDialogContext context, LuisResult result)
        {
            //  await context.PostAsync("Are you referring to section Part 1 of Information sheet?");
            // context.Wait(this.MessageReceived);
            priorintent = "Informationsheet";
            await this.InformationSheetAsync(context, "Are you referring to section Part 1 of Information sheet ?");

        }

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.";
            priorintent = "None";
            await context.PostAsync(message);
            
            context.Wait(this.MessageReceived);
        }

        private async Task WelcomeMessageAsync(IDialogContext context)
        {
            var reply = context.MakeMessage();

            var options = new[]
            {
                Resources.RootDialog_Welcome_Protocol,
                Resources.RootDialog_Welcome_Checklist,
                Resources.RootDialog_Welcome_Criteria,
                Resources.RootDialog_Welcome_AdverseEvents,
                Resources.RootDialog_Welcome_ProtocolDeviations,
                Resources.RootDialog_Welcome_Feedback,
                Resources.RootDialog_Welcome_Support

            };
            reply.AddHeroCard(
                Resources.RootDialog_Welcome_Title,
                Resources.RootDialog_Welcome_Subtitle,
                options,
                new[] { "http://res.cloudinary.com/ctimages/image/upload/v1504042917/welcomebot_ou4h2n.png" });

            await context.PostAsync(reply);

            context.Wait(this.OnOptionSelected);
        }


        private async Task OnOptionSelected(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            if (message.Text == Resources.RootDialog_Welcome_Protocol)
            {
                await context.PostAsync("Hi, Do you need assistance on consent form?");
                context.Wait(this.MessageReceived);

               
            }
            else if (message.Text == Resources.RootDialog_Welcome_Support)
            {
                await this.StartOverAsync(context, Resources.RootDialog_Support_Message);
            }
            else
            {
                await this.StartOverAsync(context, Resources.RootDialog_Welcome_Error);
            }
        }

        private async Task InformationSectionMessageAsync(IDialogContext context)
        {
            var reply = context.MakeMessage();

            var options = new[]
            {
                Resources.RootDialog_OptionYes,
                Resources.RootDialog_OptionNo


            };

            reply.AddHeroCard(
                "Informed consent clinical studies",
                "Page2 - Part1 of Information sheet",
                options,
                new[] { "http://res.cloudinary.com/ctimages/image/upload/v1504593728/Part_1_-_Information_sheet_-_Informed_consent_clinical_studies-v3_ihnxv9.png" }
                //"BotFramework Hero Card",
                //"Your bots — wherever your users are talking",
                //"Build and connect intelligent bots to interact with your users naturally wherever they are, from text/sms to Skype, Slack, Office 365 mail and other popular services.",
                //new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg"),
                //new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") 
                );





            await context.PostAsync(reply);

            context.Wait(this.OnInformationSelectionOptionSelected);
        }

        private async Task OnInformationSelectionOptionSelected(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            if (message.Text == Resources.RootDialog_OptionYes)
            {
                await context.PostAsync("Great!! Do you have any other questions...");
                context.Wait(this.MessageReceived);

            }

            else
            {
                await context.PostAsync("Hmm, sorry may be I didnt get your question correctly. Can you please rephrase your question for me.");
                context.Wait(this.MessageReceived);

            }
        }

        private async Task ParticipationMessageAsync(IDialogContext context)
        {
            var reply = context.MakeMessage();

            var options = new[]
            {
                Resources.RootDialog_OptionYes,
                Resources.RootDialog_Welcome_Support


            };
            reply.AddHeroCard(
                "Trial inclusion Criteria",
                "Page 14 of protocol template version 1.05.23.16",
                options,
                new[] { "http://res.cloudinary.com/ctimages/image/upload/v1504673122/Participation_criteriav2_jedv9t.png" });

            await context.PostAsync(reply);

            context.Wait(this.OnParticipationOptionSelected);
        }

        private async Task OnParticipationOptionSelected(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            if (message.Text == Resources.RootDialog_OptionYes)
            {
                await context.PostAsync("Is there anything else I can help you with");
                context.Wait(this.MessageReceived);

            }

            else
            {
                await context.PostAsync("Please wait... i'm connecting to CRA");
                //await this.StartOverAsync(context, Resources.RootDialog_Greeting);
                context.Wait(this.MessageReceived);

            }
        }


        private async Task StartOverAsync(IDialogContext context, string text)
        {
            var message = context.MakeMessage();
            message.Text = text;
            await this.StartOverAsync(context, message);
        }

        private async Task StartOverAsync(IDialogContext context, IMessageActivity message)
        {
            await context.PostAsync(message);
           // this.order = new Models.Order();
            await this.WelcomeMessageAsync(context);
        }

        private async Task InformationSheetAsync(IDialogContext context, string text)
        {
            var message = context.MakeMessage();
            message.Text = text;
            await this.InformationSheetAsync(context, message);
        }

        private async Task InformationSheetAsync(IDialogContext context, IMessageActivity message)
        {
            await context.PostAsync(message);
            // this.order = new Models.Order();
            await this.InformationSectionMessageAsync(context);
        }

        private async Task ParticipationAsync(IDialogContext context, string text)
        {
            var message = context.MakeMessage();
            message.Text = text;
            await this.ParticipationAsync(context, message);
        }

        private async Task ParticipationAsync(IDialogContext context, IMessageActivity message)
        {
            await context.PostAsync(message);
            // this.order = new Models.Order();
            await this.ParticipationMessageAsync(context);
        }

    }
}
