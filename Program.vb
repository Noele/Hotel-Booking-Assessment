Imports System

Module Program

    'Const - Constant variable, They cannot be changed during runtime
    Const SINGLEROOM As Integer = 47 'Create a Constant variable called SINGLEROOM as an integer and assign its value as 47
    Const DOUBLEROOM As Integer = 90 'Create a Constant variable called DOUBLEROOM as an integer and assign its value as 90
    Const FAMILYSUITE As Integer = 250 'Create a Constant variable called FAMILYSUITE as an integer and assign its value as 250


    'Dim - Dimension variable, They can be changed during runtime
    Dim rooms As New ArrayList 'Create an array called rooms, We will store the rooms booked in here
    Dim numberOfRooms As Integer 'Create a variable called numberOfRooms as an integer, We will store the number of rooms they want to book here
    Dim numberOfNights As Integer 'Create a variable called numberOfNights as an integer, We will store their length of stay here

    Dim familyName As String = "" 'Create a variable called familyName as a string, This is where we will store the family name
    Dim arrivalDate As DateTime 'Create a variable called arrivalDate as a DateTime, This will be how we convert their stay to the appropriate formatting 
    Dim totalCost As Integer 'Varaible to add the rooms costs together to get the final cost
    Dim input As String 'Variable we add to accept placeholder inputs

    Sub Main(args As String())
        While (String.IsNullOrEmpty(familyName.Replace(" ", "")))
            Console.WriteLine("Hello ! Please enter your family name :")
            familyName = Console.ReadLine()
            Console.Clear()
        End While

        Console.WriteLine("Thank you ! Please enter your arrival date (Please use the format dd/mm/yyyy")
        While (True)
            Try
                arrivalDate = Console.ReadLine
                Console.Clear()
                Exit While
            Catch ex As InvalidCastException
                Console.WriteLine("That was not a valid date ! Please stik to the format dd/mm/yyyy")
            End Try
        End While

        Console.WriteLine("Thank you ! Please enter the number of nights you wish to stay for. The stay is 14 nights")
        While Not (numberOfNights > 0 And numberOfNights <= 14)
            Try
                numberOfNights = Console.ReadLine()
                If Not (numberOfNights > 0 And numberOfNights <= 14) Then
                    Console.Clear()
                    Console.WriteLine($"{numberOfNights} is not a valid stay length ! Please choose a number between 1 - 14")
                End If
            Catch ex As InvalidCastException
                Console.Clear()
                Console.WriteLine("That is not a valid number ! Please try again")
            End Try

        End While

        Console.WriteLine("Thank you ! We will now display your current data !" + vbCrLf + "Please press enter to continue ...")
        Console.ReadLine()
        UpdateDisplay()

        Console.WriteLine("Now please enter what room you want to book, Your options are - ""Single Room"", ""Double Room"" and ""Family Suite""" + vbCrLf)
        RequestRooms()


    End Sub

    Sub UpdateDisplay()
        Console.Clear()
        Console.WriteLine("Family Name: " & familyName)
        Console.WriteLine("Arrival Date: " & arrivalDate)
        Console.WriteLine("Number of Nights: " & numberOfNights & vbCrLf)
        If rooms.Count > 0 Then
            Console.WriteLine("Rooms Booked:             Cost:")
            For i = 0 To rooms.Count - 1
                If (rooms(i) = SINGLEROOM) Then
                    Console.WriteLine("Single Room               £" + SINGLEROOM.ToString)
                ElseIf (rooms(i) = DOUBLEROOM) Then
                    Console.WriteLine("Double Room               £" + DOUBLEROOM.ToString)
                ElseIf (rooms(i) = FAMILYSUITE) Then
                    Console.WriteLine("Family Suite              £" + FAMILYSUITE.ToString)
                End If
            Next
            Console.WriteLine(vbCrLf + "Total Cost:               £" & calculateTotalCost(rooms))
        End If
    End Sub

    Sub RequestRooms()
        For i = 1 To 3
            If i > 1 Then
                Console.WriteLine("Please add another room to your cart, Or type ""exit"" to finish adding rooms, Your options are - ""Single Room"", ""Double Room"" and ""Family Suite""" + vbCrLf)
            End If
            input = Console.ReadLine()

            If input.ToLower.Contains("single") Then
                rooms.Add(SINGLEROOM)
                UpdateDisplay()
                Console.WriteLine(vbCrLf + "Thank you, We have added 1 Single Room to your cart")
            ElseIf input.ToLower.Contains("double") Then
                rooms.Add(DOUBLEROOM)
                UpdateDisplay()
                Console.WriteLine(vbCrLf + "Thank you, We have added 1 Double Room to your cart")
            ElseIf input.ToLower.Contains("family") Then
                rooms.Add(FAMILYSUITE)
                UpdateDisplay()
                Console.WriteLine(vbCrLf + "Thank you, We have added 1 Family Suite to your cart")
            ElseIf input.ToLower = "exit" Then
                Exit For
            Else
                Console.WriteLine("Please select a valid option !")
                i -= 1
            End If
        Next
    End Sub

    Function calculateTotalCost(ArrayList)
        totalCost = 0
        For Each room In ArrayList
            If (room = SINGLEROOM) Then
                totalCost += SINGLEROOM
            ElseIf (room = DOUBLEROOM) Then
                totalCost += DOUBLEROOM
            ElseIf (room = FAMILYSUITE) Then
                totalCost += FAMILYSUITE
            End If
        Next
        Return totalCost
    End Function
End Module
