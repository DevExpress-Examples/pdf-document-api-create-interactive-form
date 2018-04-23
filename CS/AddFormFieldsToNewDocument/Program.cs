using DevExpress.Pdf;
using System.Drawing;

namespace AddFormFieldsToNewDocument {
    class Program {
        static void Main(string[] args) {
            using (PdfDocumentProcessor processor = new PdfDocumentProcessor()) {

                // Create an empty document. 
                processor.CreateEmptyDocument("..\\..\\Result.pdf");

                // Create graphics and draw form fields.
                using (PdfGraphics graphics = processor.CreateGraphics()) {
                    DrawFormFields(graphics);

                    // Render a page with graphics.
                    processor.RenderNewPage(PdfPaperSize.Letter, graphics);
                }
            }
        }

        static void DrawFormFields(PdfGraphics graphics) {

            // Create a text box field and specify its location on the page.
            PdfGraphicsAcroFormTextBoxField textBox = new PdfGraphicsAcroFormTextBoxField("text box", new RectangleF(30, 10, 200, 30));

            // Specify text box text, and appearance.
            textBox.Text = "Text Box";
            textBox.Appearance.FontSize = 12;
            textBox.Appearance.BackgroundColor = Color.AliceBlue;

            // Add the text box field to graphics.
            graphics.AddFormField(textBox);

            // Create a radio group field.
            PdfGraphicsAcroFormRadioGroupField radioGroup = new PdfGraphicsAcroFormRadioGroupField("First Group");

            // Add the first radio button to the group and specify its location using a RectangleF object.
            radioGroup.AddButton("button1", new RectangleF(30, 60, 20, 20));

            // Add the second radio button to the group.
            radioGroup.AddButton("button2", new RectangleF(30, 90, 20, 20));

            // Specify radio group selected index, and appearance. 
            radioGroup.SelectedIndex = 0;
            radioGroup.Appearance.BorderAppearance = new PdfGraphicsAcroFormBorderAppearance() { Color = Color.Red, Width = 3 };

            // Add the radio group field to graphics.
            graphics.AddFormField(radioGroup);
        }
    }
}
