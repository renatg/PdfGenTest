namespace PdfGenTest.Models;

public class ApplicationFormData
{
    public string Title { get; init; } = "APPLICATION FORM / आवेदन पत्र";
    public string DateOfApplication { get; init; } = "{03.01.2025}";
    public string DigitalLendingApplication { get; init; } = "Vivamoney Solutions Private Limited ('Vivamoney')";
    public string ApplicationNumber { get; init; } = "{2714332}";
    public ApplicantDetails Applicant { get; init; } = new();
    public ApplicantContacts Contacts { get; init; } = new();
    public IList<LoanDetail> LoanDetails { get; init; } = new List<LoanDetail>();
    public IList<ContingentCharge> ContingentCharges { get; init; } = new List<ContingentCharge>();
    public IList<string> DocumentsToProvide { get; init; } = new List<string>();
    public IList<string> DocumentTypes { get; init; } = new List<string>();
    public CustomerAcknowledgement Acknowledgement { get; init; } = new();
    public IList<OtherCondition> OtherConditions { get; init; } = new List<OtherCondition>();

    public static ApplicationFormData CreateDefault() => new()
    {
        Applicant = new ApplicantDetails
        {
            Name = "{Goranshi Jain}",
            DateOfBirth = "Dd/mm/yyyy",
            SourceOfIncome = "{}",
            Gender = "{}",
            MonthlyIndividualIncome = "{}",
            Industry = "{}",
            CKYCId = string.Empty
        },
        Contacts = new ApplicantContacts
        {
            ResidentialAddress = "K-1, Landmark City, Kunhari, Kota",
            Email = "{}",
            Mobile = "{9468663854}"
        },
        LoanDetails =
        [
            new LoanDetail("(i)", "Requested Loan Amount (Rs.)/ अनुरोधित ऋण राशि (रु)", string.Empty),
            new LoanDetail("(ii)", "Tenure of the Loan (Months)/ लोन की अवधि (महीना)", string.Empty),
            new LoanDetail("(iii)", "Processing Fee- First Disbursal (%) / प्रोसेसिंग शुल्क (%)", string.Empty),
            new LoanDetail("(iv)", "Processing Fee- Subsequent Disbursal (%)/ प्रोसेसिंग शुल्क (%)", string.Empty),
            new LoanDetail("(v)", "Annualised Rate of Interest (%)/ब्याज दर (%)", string.Empty)
        ],
        ContingentCharges =
        [
            new ContingentCharge("(i)", "Penal charges (Rs)/ दंडात्मक शुल्क (रुपए)",
                "1 - 9 days overdue – ₹{118} 10 – 29 days overdue –₹{118}\n30 – 59 days overdue – ₹{236}60 days and above overdue – ₹{354} for every 30 days"),
            new ContingentCharge("(ii)", "Grace Repayment Fee (%)/ग्रेस रिपेमेंट शुल्क (%)", "1.77% of grace repayment amount"),
            new ContingentCharge("(iii)", "Early Repayment/Foreclosure Charges (%)/समय से पहले पुनर्भुगतान/ फोर क्लोज़र शुल्क (%)", "4.72% of the outstanding principal debt amount"),
            new ContingentCharge("(iv)", "SMS Charges (Rs)/ एसएमएस शुल्क (रुपए)", "₹82 per month"),
            new ContingentCharge("(v)", "Term Fee (Rs) / वैकल्पिक टर्म शुल्क (रुपए)", "5 months – 0; 10 months – ₹1179; 20 months – ₹1769")
        ],
        DocumentsToProvide =
        [
            "Identity Proof & Address Proof/ पहचान प्रमाण और पता प्रमाण",
            "PAN, Aadhaar (masked)/ पैन, आधार (मास्क)",
            "Bank Statement/ बैंक स्टेटमेंट"
        ],
        DocumentTypes =
        [
            "PAN /पैन",
            "Aadhar /आधार"
        ],
        Acknowledgement = new CustomerAcknowledgement
        {
            English = "Yes, I would like to obtain the facility for applying and obtaining Loan from FincFriends Private Limited (FincFriends) over the phone, e-mail, SMS, FincFriends's customer portal (i.e. Communication Mode) as per the applicable terms and conditons of FincFriends.",
            Hindi = "हां, मैं फिंकफ्रेंड्स प्राइवेट लिमिटेड (\"फिंकफ्रेंड्स\") से, लागू शर्तों के अनुसार, फोन, ई-मेल, एसएमएस, या  फिंकफ्रेंड्स के ग्राहक पोर्टल (यानी संपर्क विकल्प) द्वारा ऋण आवेदन और प्राप्त करने की सुविधा प्राप्त करना चाहता/चाहती हूं"
        },
        OtherConditions =
        [
            new OtherCondition("1",
                "I hereby confirm that I am a citizen of India and competent to give this declaration/ undertaking and to execute and submit this Application Form and all other documents for the purpose of availing loan and representing generally for all the purposes mentioned/required to be done for these presents./",
                "मैं एतद्द्वारा पुष्टि करता हूँ कि मैं भारत का नागरिक हूँ और यह घोषणा/वचन देने तथा ऋण प्राप्त करने के लिए इस आवेदन पत्र और अन्य सभी दस्तावेजों को निष्पादित करने और प्रस्तुत करने तथा इन प्रस्तुतियों के लिए वर्णित/अपेक्षित सभी उद्देश्यों के लिए सामान्य रूप से प्रतिनिधित्व करने के लिए सक्षम हूँ।"),
            new OtherCondition("2",
                "I confirm that all the particulars and information given in the application form and otherwise in writing or over the Communciations Modes by me, are true, correct and complete and no information has been withheld/suppressed.",
                "मैं पुष्टि करता हूँ कि आवेदन पत्र में तथा मेरे द्वारा लिखित रूप में या संचार माध्यमों से दी गई सभी जानकारी और विवरण सत्य, सही और पूर्ण हैं तथा कोई भी जानकारी छिपाई/दबाई नहीं गई है।"),
            new OtherCondition("3",
                "I understand and agree that Fincfriends doesn’t grant any microfinance loans and confirm that my household income (covering income of husband/ wife and unmarried children) is more than Rs. 25,000/- per month. I further agree that I will not make Fincfriends liable should Fincfriends grants any loan or finance facility to me relying upon this declaration.",
                "मैं समझता हूँ और सहमत हूँ कि फ़िंकफ़्रेंड्स कोई माइक्रोफ़ाइनेंस लोन नहीं देता है और पुष्टि करता हूँ कि मेरी घरेलू आय (पति/पत्नी और अविवाहित बच्चों की आय को शामिल करते हुए) 25,000/- रुपये प्रति माह से अधिक है। मैं आगे सहमत हूँ कि अगर फ़िंकफ़्रेंड्स इस घोषणा के आधार पर मुझे कोई लोन या वित्त सुविधा देता है तो मैं फ़िंकफ़्रेंड्स को उत्तरदायी नहीं ठहराऊँगा।"),
            new OtherCondition("4",
                "I confirm that I am submitting this application form after having read and fully understood the Privacy Policy & Interest Rate & Charges Policy (as amended from time to time) of Fincfriends as well as the terms and conditions of availing loan from Fincfriends. I acknowledge that Fincfriends shall be entitled to reject my application without assigning any reason.",
                "मैं पुष्टि करता हूँ कि मैं फिनकफ्रेंड्स की गोपनीयता नीति और ब्याज दर और ब्याज नीति (समय-समय पर संशोधित) के साथ-साथ फिनकफ्रेंड्स से ऋण प्राप्त करने की शर्तों और नियमों को पढ़ने और पूरी तरह से समझने के बाद यह आवेदन पत्र जमा कर रहा हूँ। मैं स्वीकार करता हूँ कि फिनकफ्रेंड्स बिना कोई कारण ताए मेरे आवेदन को अस्वीकार करने का हकदार होगा।"),
            new OtherCondition("5",
                "I have no insolvency proceedings against me nor have I ever been adjudicated insolvent.  I confirm that no suit for recovery of outstanding dues or monies whatsoever and/or criminal proceedings have been initiated and/or pending against me. There is no restriction on me in respect of availing the loan from Fincfriends and no person's consent is required by me for availing the loan from Fincfriends.",
                "मेरे खिलाफ कोई दिवालियापन कार्यवाही नहीं है और न ही मुझे कभी दिवालिया घोषित किया गया है। मैं पुष्टि करता हूं कि बकाया राशि या धन की वसूली के लिए कोई मुकदमा या/या आपराधिक कार्यवाही मेरे खिलाफ शुरू नहीं की गई है और/या लंबित नहीं है। फिंकफ्रेंड्स से ऋण प्राप्त करने के संबंध में मुझ पर कोई प्रतिबंध नहीं है और फिंकफ्रेंड्स से ऋण प्राप्त करने के लिए मुझे किसी व्यक्ति की सहमति की आवश्यकता नहीं है।"),
            new OtherCondition("6",
                "Due date shall be communicated through Communication Mode at the time of disbursement via verified email/SMS/WhatsApp.",
                "नियत तिथि, लोन राशि के संवितरण के समय, संपर्क विकल्प जैसे ईमेल/एसएमएस/व्हाट्सऐप के माध्यम से साझा की जाएगी।"),
            new OtherCondition("7",
                "All fees and charges, if not specified otherwise, are inclusive of all taxes.",
                "सभी फीस और शुल्क, यदि अन्यथा निर्दिष्ट नहीं हैं, तो कर सहित ।"),
            new OtherCondition("8",
                "FincFriends may at its own discretion decide not to levy or waive/discount any charges/penalty earlier levied on the Loan.",
                "फिंकफ्रेंड्स अपने स्वविवेक से लोन पर पहले लगाए गए किसी भी शुल्क/जुर्माने को नहीं लगाने या माफ/छूट करने का निर्णय ले सकती है।"),
            new OtherCondition("9",
                "Though the validity period of the Credit Limit is restrcited to 72 months subject to adherance of the terms and conditions by the customer and sole discretion of Fincfriends, each  withdrawal under the Credit Limit is repayable by the customer in the monthly instalments of 5, 10 or 20 months as opted by the customer at the time of each such withdrawal. Accordingly, the fees and charges shall be determined and levied accordingly.",
                "क्रेडिट लिमिट की वैधता अवधि 72 माह तक सीमित रहेगी, जो ग्राहक द्वारा नियमों और शर्तों के पालन तथा फिन्कफ्रेंड्स के पूर्ण विवेकाधिकार पर निर्भर होगी। क्रेडिट लिमिट के अंतर्गत की गई प्रत्येक निकासी ग्राहक द्वारा उस समय चुने गए विकल्प के अनुसार 5, 10 या 20 माह की मासिक किस्तों में चुकाई जाएगी। तदनुसार, लागू शुल्क और प्रभार निर्धारित किए जाएंगे और उसी प्रकार वसूल किए जाएंगे")
        ]
    };

    public class ApplicantDetails
    {
        public string Name { get; init; } = string.Empty;
        public string DateOfBirth { get; init; } = string.Empty;
        public string SourceOfIncome { get; init; } = string.Empty;
        public string Gender { get; init; } = string.Empty;
        public string MonthlyIndividualIncome { get; init; } = string.Empty;
        public string Industry { get; init; } = string.Empty;
        public string CKYCId { get; init; } = string.Empty;
    }

    public class ApplicantContacts
    {
        public string ResidentialAddress { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Mobile { get; init; } = string.Empty;
    }

    public record LoanDetail(string Index, string Label, string Value);

    public record ContingentCharge(string Index, string Label, string Value);

    public class CustomerAcknowledgement
    {
        public string English { get; init; } = string.Empty;
        public string Hindi { get; init; } = string.Empty;
    }

    public record OtherCondition(string Number, string English, string Hindi);
}
