
''James Morand
''Visual Basic 105 
''Project_4
''Professor: Ron Kessller
''4/25/2018


Public Class Form1

    ''global values for math calculations

    Dim quantity = 0
    Dim price = 0
    Dim tax = 0
    Dim taxpercent = 0.08D
    Dim subtotal = 0
    Dim total = 0


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        picLogo.Image = Image.FromFile("..\..\pics\logo.png")

        ''create items in listbox with a name, price, and image
        lstItems.Items.Add("Clutch                        400.00                                 clutch.jpg")
        lstItems.Items.Add("Spark Plugs                   10.00                                sparkplug.jpg")
        lstItems.Items.Add("Rear Tire                     150.00                               reartire.jpg")
        lstItems.Items.Add("Front Tire                    120.00                              FrontTire.jpg")
        lstItems.Items.Add("Helmet                        650.00                                 helmet.jpg")
        lstItems.Items.Add("Gloves                        135.00                                  glove.jpg")
        lstItems.Items.Add("Boots                         420.00                                   boot.jpg")
        lstItems.Items.Add("Jacket                        350.00                                 jacket.jpg")
        lstItems.Items.Add("Pants                         440.00                                  pants.jpg")
        lstItems.Items.Add("Track Suit                   1150.00                                   suit.jpg")
        lstItems.Items.Add("Fule Additive                   5.00                               fuleadditive.jpg")
        lstItems.Items.Add("Phone Mount                    75.00                               phonemount.jpg")
        lstItems.Items.Add("Communicator                  250.00                                 sena20.jpg")
        lstItems.Items.Add("Helmet Visor                   50.00                                 visors.jpg")
        lstItems.Items.Add("Key Chain                     150.00                               keychain.jpg")


        lstItems.SelectedIndex = 0


    End Sub

    Private Sub lstItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstItems.SelectedIndexChanged

        txtPrice.Text = ""
        txtQuantity.Text = 1

        Dim ItemName As String = ""
        Dim ItemPrice As String = ""
        Dim Itempicture As String = ""

        ''trim the name, price, and image from the listbox
        ItemName = Trim(Mid(lstItems.SelectedItem, 1, 16))
        ItemPrice = Trim(Mid(lstItems.SelectedItem, 16, 25))
        Itempicture = Trim(Mid(lstItems.SelectedItem, 50))

        ''set textbox as tim values
        txtItem.Text = ItemName
        txtPrice.Text = FormatCurrency(Convert.ToDouble(ItemPrice))

        ''display image of item in picture box 
        pic.Image = Image.FromFile("..\..\pics\" & Itempicture)

        ''calculate subtotal
        price = CDbl(txtPrice.Text)
        quantity = CInt(txtQuantity.Text)

        subtotal = FormatCurrency(quantity * price)
        txtSubTotal.Text = subtotal

    End Sub

    ''update button will recalculate the subtotal with the changed quantity
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ''update subtotal with new quantity
        price = CDbl(txtPrice.Text)
        quantity = CDbl(txtQuantity.Text)
        ''subtotal calculations
        subtotal = FormatCurrency(quantity * price)
        txtSubTotal.Text = subtotal

    End Sub

    ''reset and start from the beginning
    Private Sub btnClearOrder_Click(sender As Object, e As EventArgs) Handles btnClearOrder.Click

        lstItems.ClearSelected()
        txtTotal.Clear()
        txtTax.Clear()
        txtQuantity.Focus()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ''message box with warning to make sure they want to leave
        If MessageBox.Show("You sure you want to leave?", "Warning!", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Warning) = MsgBoxResult.Yes Then
            ''close the application
            Me.Close()
        Else
            ''do nothihng
        End If
    End Sub

    Private Sub btnCheckOut_Click(sender As Object, e As EventArgs) Handles btnCheckOut.Click
        If MessageBox.Show("Are you ready to check out?", "Shopping Cart", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            price = CDbl(txtPrice.Text)
            quantity = CDbl(txtQuantity.Text)

            ''calculations
            tax = taxpercent * subtotal
            total = tax + price
            subtotal = FormatCurrency(quantity * price)

            ''display the calculations
            txtSubTotal.Text = FormatCurrency(subtotal)
            txtTax.Text = FormatCurrency(tax)
            txtTotal.Text = FormatCurrency(total)

            ''goodbye message with grand total and close application
            MessageBox.Show("Your total was " + txtTotal.Text, "Thanks For Shopping", MessageBoxButtons.OK)
            Me.Close()

        Else
            ''do nothing and return for shopping
        End If
    End Sub
End Class
