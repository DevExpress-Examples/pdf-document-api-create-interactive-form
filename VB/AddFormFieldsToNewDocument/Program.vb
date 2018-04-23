Imports DevExpress.Pdf
Imports System.Drawing

Namespace AddFormFieldsToNewDocument
    Friend Class Program
        Shared Sub Main(ByVal args() As String)
            Using processor As New PdfDocumentProcessor()

                ' Create an empty document. 
                processor.CreateEmptyDocument("..\..\Result.pdf")

                ' Create graphics and draw form fields.
                Using graphics As PdfGraphics = processor.CreateGraphics()
                    DrawFormFields(graphics)

                    ' Render a page with graphics.
                    processor.RenderNewPage(PdfPaperSize.Letter, graphics)
                End Using
            End Using
        End Sub

        Private Shared Sub DrawFormFields(ByVal graphics As PdfGraphics)

            ' Create a text box field and specify its location on the page.
            Dim textBox As New PdfGraphicsAcroFormTextBoxField("text box", New RectangleF(30, 10, 200, 30))

            ' Specify text box text, and appearance.
            textBox.Text = "Text Box"
            textBox.Appearance.FontSize = 12
            textBox.Appearance.BackgroundColor = Color.AliceBlue

            ' Add the text box field to graphics.
            graphics.AddFormField(textBox)

            ' Create a radio group field.
            Dim radioGroup As New PdfGraphicsAcroFormRadioGroupField("First Group")

            ' Add the first radio button to the group and specify its location using a RectangleF object.
            radioGroup.AddButton("button1", New RectangleF(30, 60, 20, 20))

            ' Add the second radio button to the group.
            radioGroup.AddButton("button2", New RectangleF(30, 90, 20, 20))

            ' Specify radio group selected index, and appearance. 
            radioGroup.SelectedIndex = 0
            radioGroup.Appearance.BorderAppearance = New PdfGraphicsAcroFormBorderAppearance() With {.Color = Color.Red, .Width = 3}

            ' Add the radio group field to graphics.
            graphics.AddFormField(radioGroup)
        End Sub
    End Class
End Namespace
