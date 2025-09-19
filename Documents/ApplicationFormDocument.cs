using PdfGenTest.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace PdfGenTest.Documents;

public class ApplicationFormDocument(ApplicationFormData data) : IDocument
{
    private readonly ApplicationFormData _data = data;

    private static readonly TextStyle NormalStyle = TextStyle.Default.FontSize(10);
    private static readonly TextStyle SectionTitleStyle = TextStyle.Default.FontSize(11).SemiBold();
    private static readonly TextStyle HeaderStyle = TextStyle.Default.FontSize(16).SemiBold();
    private static readonly TextStyle SubHeaderStyle = TextStyle.Default.FontSize(10).SemiBold();

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public DocumentSettings GetSettings() => new()
    {
        PaperSize = PageSizes.A4,
        Margins = new PageMargins(40)
    };

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.DefaultTextStyle(NormalStyle);

            page.Content().Column(column =>
            {
                column.Spacing(12);

                column.Item().AlignCenter().Text(text => text.Span(_data.Title).Style(HeaderStyle));

                column.Item().Text(text =>
                {
                    text.Span("Date of Application/तिथि: ").Style(SubHeaderStyle);
                    text.Span(_data.DateOfApplication);
                });

                column.Item().Text(text =>
                {
                    text.Span("Digital Lending Application/ डिजिटल लेंडिंग एप्लीकेशन: ").Style(SubHeaderStyle);
                    text.Span(_data.DigitalLendingApplication);
                });

                column.Item().Text(text =>
                {
                    text.Span("Application No / आवेदन संख्या: ").Style(SubHeaderStyle);
                    text.Span(_data.ApplicationNumber);
                });

                column.Item().Element(ComposeApplicantDetails);
                column.Item().Element(ComposeApplicantContacts);
                column.Item().Element(ComposeLoanDetails);
                column.Item().Element(ComposeContingentCharges);
                column.Item().Element(ComposeDocumentsToProvide);
                column.Item().Element(ComposeDocumentTypes);
                column.Item().Element(ComposeAcknowledgement);
                column.Item().Element(ComposeOtherConditions);
            });
        });
    }

    private void ComposeApplicantDetails(IContainer container)
    {
        ComposeSection(container, "APPLICANT DETAIL /आवेदक का विवरण", content =>
        {
            ComposeKeyValueTable(content, new (string Label, string Value)[]
            {
                ("Name/ नाम", _data.Applicant.Name),
                ("Date of Birth/ जन्म तिथि", _data.Applicant.DateOfBirth),
                ("Source of Income/ आय का स्रोत", _data.Applicant.SourceOfIncome),
                ("Gender / लिंग", _data.Applicant.Gender),
                ("Monthly Individual Income (Rs.)/ मासिक व्यक्तिगत आय (₹)", _data.Applicant.MonthlyIndividualIncome),
                ("Industry/ उद्योग", _data.Applicant.Industry),
                ("CKYC ID/ सीकेवाईसी आईडी", _data.Applicant.CKYCId)
            });
        });
    }

    private void ComposeApplicantContacts(IContainer container)
    {
        ComposeSection(container, "APPLICANT CONTACTS/आवेदक का संपर्क", content =>
        {
            ComposeKeyValueTable(content, new (string Label, string Value)[]
            {
                ("Residential Address / आवासीय पता", _data.Contacts.ResidentialAddress),
                ("E-mail address / ईमेल पता", _data.Contacts.Email),
                ("Mobile No./ मोबाइल न.", _data.Contacts.Mobile)
            });
        });
    }

    private void ComposeLoanDetails(IContainer container)
    {
        ComposeSection(container, "LOAN DETAIL/ लोन विवरण", content =>
        {
            ComposeIndexedTable(content, _data.LoanDetails.Select(item => (item.Index, item.Label, item.Value)));
        });
    }

    private void ComposeContingentCharges(IContainer container)
    {
        ComposeSection(container, "DETAIL OF CONTINGENT CHARGES /आकस्मिक शुल्क का विवरण", content =>
        {
            ComposeIndexedTable(content, _data.ContingentCharges.Select(item => (item.Index, item.Label, item.Value)));
        });
    }

    private void ComposeDocumentsToProvide(IContainer container)
    {
        ComposeSection(container, "DOCUMENTS TO PROVIDE WITH LOAN APPLICATION/लोन आवेदन के साथ प्रदान किये जाने वाले दस्तावेज़", content =>
        {
            ComposeIndexedList(content, _data.DocumentsToProvide);
        });
    }

    private void ComposeDocumentTypes(IContainer container)
    {
        ComposeSection(container, "Document Type/डॉक्यूमेंट प्रकार", content =>
        {
            ComposeIndexedList(content, _data.DocumentTypes);
        });
    }

    private void ComposeAcknowledgement(IContainer container)
    {
        ComposeSection(container, "Customer Acknowledgement/ ग्राहक स्वीकृति:", content =>
        {
            content.Column(column =>
            {
                column.Spacing(4);
                column.Item().Text(_data.Acknowledgement.English);
                column.Item().Text(_data.Acknowledgement.Hindi);
            });
        });
    }

    private void ComposeOtherConditions(IContainer container)
    {
        ComposeSection(container, "Other Conditions /अन्य शर्तें :", content =>
        {
            content.Column(column =>
            {
                column.Spacing(6);

                foreach (var item in _data.OtherConditions)
                {
                    column.Item().Row(row =>
                    {
                        row.ConstantColumn(20).Text(item.Number).Style(SubHeaderStyle);
                        row.RelativeColumn().Column(inner =>
                        {
                            inner.Item().Text(item.English);
                            inner.Item().Text(item.Hindi);
                        });
                    });
                }
            });
        });
    }

    private static void ComposeSection(IContainer container, string title, Action<IContainer> content)
    {
        container.Column(column =>
        {
            column.Spacing(6);
            column.Item().Text(title).Style(SectionTitleStyle);
            column.Item().Element(content);
        });
    }

    private static void ComposeKeyValueTable(IContainer container, IEnumerable<(string Label, string Value)> rows)
    {
        container.Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                columns.ConstantColumn(210);
                columns.RelativeColumn();
            });

            foreach (var (label, value) in rows)
            {
                table.Cell().Element(CellLabel).Text(label).Style(SubHeaderStyle);
                table.Cell().Element(CellValue).Text(value);
            }
        });
    }

    private static void ComposeIndexedTable(IContainer container, IEnumerable<(string Index, string Label, string Value)> rows)
    {
        container.Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                columns.ConstantColumn(20);
                columns.RelativeColumn(2);
                columns.RelativeColumn();
            });

            foreach (var (index, label, value) in rows)
            {
                table.Cell().Element(CellLabel).Text(index).Style(SubHeaderStyle);
                table.Cell().Element(CellLabel).Text(label);
                table.Cell().Element(CellValue).Text(value);
            }
        });
    }

    private static void ComposeIndexedList(IContainer container, IEnumerable<string> rows)
    {
        var items = rows.ToList();
        container.Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                columns.ConstantColumn(20);
                columns.RelativeColumn();
            });

            for (var i = 0; i < items.Count; i++)
            {
                var index = i switch
                {
                    0 => "(i)",
                    1 => "(ii)",
                    2 => "(iii)",
                    3 => "(iv)",
                    4 => "(v)",
                    _ => $"({i + 1})"
                };

                table.Cell().Element(CellLabel).Text(index).Style(SubHeaderStyle);
                table.Cell().Element(CellValue).Text(items[i]);
            }
        });
    }

    private static IContainer CellLabel(IContainer container) => container.PaddingVertical(3).PaddingRight(8);

    private static IContainer CellValue(IContainer container) => container.PaddingVertical(3);
}
