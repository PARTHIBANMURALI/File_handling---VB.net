Imports System
Imports System.Collections.Generic
Imports System.IO

Module Program
    Dim menuItems As New Dictionary(Of Integer, (String, Integer))()
    Dim billNumber As Integer = 1000

    Sub Main(args As String())
        menuItems.Add(1, ("Chicken Biryani", 250))
        menuItems.Add(2, ("Mutton Biryani", 350))
        menuItems.Add(3, ("Veg Biryani", 210))
        menuItems.Add(4, ("Chicken 65", 150))
        menuItems.Add(5, ("Pulao", 170))

        Console.WriteLine("Enter 1. Parcel 2. Dining ")
        Dim n As Integer = Convert.ToInt32(Console.ReadLine())
        If n = 1 Then
            Parcel()
        Else
            Dining()
        End If
    End Sub

    Sub Parcel()
        Dim ord As String = "yes"
        Dim orders As New List(Of (String, Integer, Integer))()

        Do While ord = "yes"
            Dim menuItem As (String, Integer) = MenuCard()
            Console.WriteLine("You selected: " & menuItem.Item1 & ", Price: " & menuItem.Item2)

            Dim quantity As Integer
            Do
                Console.WriteLine("Enter the quantity of " & menuItem.Item1 & ": ")
                quantity = Convert.ToInt32(Console.ReadLine())
            Loop While quantity <= 0

            Dim totalPrice As Integer = menuItem.Item2 * quantity
            orders.Add((menuItem.Item1, quantity, totalPrice))

            Console.WriteLine("Add another order? (yes/no)")
            ord = Console.ReadLine().ToLower()
        Loop

        GenerateBill(orders)
    End Sub

    Sub Dining()
        Dim ord As String = "yes"
        Dim orders As New List(Of (String, Integer, Integer))()

        Do While ord = "yes"
            Dim menuItem As (String, Integer) = MenuCard()
            Console.WriteLine("You selected: " & menuItem.Item1 & ", Price: " & menuItem.Item2)

            Dim quantity As Integer
            Do
                Console.WriteLine("Enter the quantity of " & menuItem.Item1 & ": ")
                quantity = Convert.ToInt32(Console.ReadLine())
            Loop While quantity <= 0

            Dim totalPrice As Integer = menuItem.Item2 * quantity
            orders.Add((menuItem.Item1, quantity, totalPrice))

            Console.WriteLine("Add another order? (yes/no)")
            ord = Console.ReadLine().ToLower()
        Loop

        GenerateBill(orders)
    End Sub

    Sub GenerateBill(orders As List(Of (String, Integer, Integer)))
        Dim totalBill As Integer = 0
        Dim orderDateTime As String = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")
        billNumber += 1

        Dim rootPath As String = "D:\New folder\Bills"
        Dim yearPath As String = Path.Combine(rootPath, DateTime.Now.Year.ToString())
        Dim monthPath As String = Path.Combine(yearPath, DateTime.Now.ToString("MM"))
        Dim dayPath As String = Path.Combine(monthPath, DateTime.Now.ToString("dd"))
        Directory.CreateDirectory(dayPath)

        Dim fileName As String = Path.Combine(dayPath, $"{billNumber}_{orderDateTime}.txt")

        Using writer As StreamWriter = New StreamWriter(fileName)
            writer.WriteLine("Order Details (" & orderDateTime & "):")
            writer.WriteLine("===================================")
            For Each order In orders
                writer.WriteLine("Item: " & order.Item1 & ", Quantity: " & order.Item2 & ", Price: " & order.Item3)
                totalBill += order.Item3
            Next
            writer.WriteLine("===================================")
            writer.WriteLine("Total Bill: " & totalBill)
            writer.WriteLine("===================================")
        End Using

        Console.WriteLine("Your order has been placed successfully. The bill is saved as: " & fileName)
    End Sub

    Function MenuCard() As (String, Integer)
        Console.WriteLine("Welcome to our hotel")
        Console.WriteLine("+++++++MENU++++++")
        Console.WriteLine(" 00000 0000000 00 -----dining ----- parcel")
        Console.WriteLine("1. Chicken Biryani ----- 250 ----- 270")
        Console.WriteLine("2. Mutton Biryani ----- 350 ----- 370")
        Console.WriteLine("3. Veg Biryani    ----- 210 ----- 230")
        Console.WriteLine("4. Chicken 65       ----- 150 ----- 170")
        Console.WriteLine("5. Pulao           ----- 170 ----- 190")
        Dim op As Integer = Convert.ToInt32(Console.ReadLine())

        Return menuItems(op)
    End Function
End Module