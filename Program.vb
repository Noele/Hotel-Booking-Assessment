Imports System

Module Program

    'Const - Constant variable, They cannot be changed during runtime
    Const SINGLEROOM As Integer = 47 'Create a Constant variable called SINGLEROOM as an integer and assign its value as 47
    Const DOUBLEROOM As Integer = 90 'Create a Constant variable called DOUBLEROOM as an integer and assign its value as 90
    Const FAMILYSUITE As Integer = 250 'Create a Constant variable called FAMILYSUITE as an integer and assign its value as 250


    'Dim - Dimension variable, They can be changed during runtime
    Dim rooms As New ArrayList 'Create an array called rooms, We will store the rooms booked in here
    Dim numberOfNights As Integer 'Create a variable called numberOfNights as an integer, We will store their length of stay here
    Dim familyName As String = "" 'Create a variable called familyName as a string, This is where we will store the family name
    Dim arrivalDate As DateTime 'Create a variable called arrivalDate as a DateTime, This will be how we convert their stay to the appropriate formatting 
    Dim totalCost As Double 'Varaible to add the rooms costs together to get the final cost
    Dim input As String 'Variable we add to accept placeholder inputs
    Dim isDiscounted As Boolean = False
    'Main() will play the manager role to the rest of the project, calling functions and subs when they are needed while also collecting data when needed
    Sub Main()

        'INPUT - Request family name, This cannot be blank
        While (String.IsNullOrEmpty(familyName.Replace(" ", "")))
            Console.WriteLine("Hello ! Please enter your family name :")
            familyName = Console.ReadLine()
            Console.Clear()
        End While

        'INPUT - Request arrival date, This cannot be blank or an invalid DateTime.
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

        'INPUT - Request the stay length, this must be between 1 - 14, this also has to be a valid number
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

        Console.WriteLine("Thank you ! We will now display your current data !" + vbCrLf + "Please press any key to continue ...")
        Console.ReadLine() 'This line doesnt save the input of the user, we use this as a way of pausing so that the user can read the above message 
        UpdateDisplay()

        Console.WriteLine("Now please enter what room you want to book, Your options are - ""Single Room"", ""Double Room"" and ""Family Suite""" + vbCrLf)
        RequestRooms()
    End Sub

    'OUTPUT - UpdateDisplay() hold all the logic for updating the screen when we need to add information to the fourmlike output, This is used so we dont repeat ourselves all over the project
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
            Console.WriteLine($"VAT:                      £{totalCost * 0.2}")
            If (isDiscounted) Then
                Console.WriteLine($"Discount:                -£{totalCost * 0.1}")
            End If
        End If
    End Sub

    'INPUT - RequestRooms() simply asks for the type of rooms that the user wants and adds them to the arraylist, This is only here to clean up Main()
    Sub RequestRooms()
        For i = 1 To 4
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

    'RETURNS DOUBLE - calculateTotalCost() takes the rooms currently being orderd and calculates the cost of all of them, It then returns the total cost
    Function calculateTotalCost(ArrayList) 'Create a function and take in an ArrayList
        totalCost = 0 'set total cost to 0, So we have a fresh start and avoid adding to the cost that may have originaly been calculated
        For Each room In ArrayList 'Loop through the Arraylist passed to the function and assign the current item as "room"
            If (room.Equals(SINGLEROOM)) Then
                totalCost += SINGLEROOM
            ElseIf (room.Equals(DOUBLEROOM)) Then 'The rest of this is duplicated, If the room is equal to x, then add the value of x to totalCost
                totalCost += DOUBLEROOM
            ElseIf (room.Equals(FAMILYSUITE)) Then
                totalCost += FAMILYSUITE
            End If
        Next
        totalCost += (totalCost * 0.2) 'Add VAT of 20%
        If (ArrayList.Count >= 3 And numberOfNights >= 7) Then '10% discount if 3 or more rooms are booked and length of stay is 7 or more nights
            totalCost = totalCost - (totalCost * 0.1)
            isDiscounted = True
        End If
        Return totalCost 'Return the calculated cost
    End Function
End Module
