Imports System
Imports System.Collections.Immutable
Imports System.IO
Imports System.Collections.Generic
Module Program
    Sub Main(args As String())

        Dim fileobj As FileStream = New FileStream("D:\New folder\student.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim streamobj As New StreamWriter(fileobj)

        Console.WriteLine("ENTER NUMBER OF STUDENTS WANTED TO STORE in STUDENT DETAILS FORM 1 : ")
        Dim noOfstu As Int16 = Console.ReadLine()

        Dim stu As student() = New student(noOfstu) {}
        For i = 1 To noOfstu

            stu(i) = New student

            Console.Write("Student ID: ")
            stu(i).id = Console.ReadLine()

            Console.Write("Name: ")
            stu(i).name = Console.ReadLine()

            Console.Write("Department: ")
            stu(i).department = Console.ReadLine()

            Console.Write("Percentage: ")
            stu(i).percentage = Integer.Parse(Console.ReadLine())

            Console.Write("Year: ")
            stu(i).year = Console.ReadLine()

            Console.Write("College Name: ")
            stu(i).CollegeName = Console.ReadLine()

            streamobj.Write("{0}  {1}  {2}  {3}  {4}  {5} ", stu(i).id, stu(i).name, stu(i).department, stu(i).percentage, stu(i).year, stu(i).CollegeName)
        Next
        streamobj.Close()
        fileobj.Close()

        Dim fileobj2 As FileStream = New FileStream("D:\New folder\sport.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim srtreamobj2 As New StreamWriter(fileobj2)

        Console.WriteLine("ENTER NUMBER OF STUDENTS WANTED TO STORE IN STUDDENT SPORT DETAIL FORM 2 :")
        Dim noOfst As Int16 = Console.ReadLine()

        Dim spo As student() = New student(noOfst) {}
        For i = 1 To noOfst
            spo(i) = New student
            Console.Write("student ID : ")
            spo(i).id = Console.ReadLine()
            Console.Write("enter the sport play by the student :")
            spo(i).sportdetails = Console.ReadLine()

            srtreamobj2.Write("{0}  {1}", spo(i).id, spo(i).sportdetails)
            srtreamobj2.WriteLine()
        Next
        srtreamobj2.Close()
        fileobj2.Close()

        Dim txtread As TextReader = New StreamReader("D:\New folder\sport.txt")
        Console.WriteLine(txtread.ReadToEnd)

        txtread.Close()

        'Dim fileList1 As SortedDictionary(Of Int16, String)
        'For i = 1 To noOfst
        '    For j = 1 To noOfst
        '        If stu(i).id = spo(j).id Then
        '            fileList1.Add(stu(i).id, spo(j).sportdetails)
        '        End If
        '    Next
        'Next
        'For Each key As KeyValuePair(Of Int16, String) In fileList1
        '    Console.WriteLine("ID :{0}  ,SPORTDETAILS: {1}", key.Key, key.Value)
        '    Console.ReadKey()
        'Next

        Dim fileobj3 As FileStream = New FileStream("D:\New folder\final.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim strobj3 As New StreamWriter(fileobj3)
        Dim final As student() = New student(noOfst) {}
        For i = 1 To noOfst
            For j = 1 To noOfst
                If stu(i).id = spo(j).id Then
                    final(i) = New student
                    final(i).id = stu(i).id
                    final(i).name = stu(i).name
                    final(i).department = stu(i).department
                    final(i).year = stu(i).year
                    final(i).CollegeName = stu(i).CollegeName
                    final(i).sportdetails = spo(j).sportdetails
                    strobj3.Write("{0}  {1}  {2}  {3}  {4}  {5} ", final(i).id, final(i).name, final(i).department, final(i).year, final(i).CollegeName, final(i).sportdetails)
                    strobj3.WriteLine()
                End If
            Next j
        Next i
        strobj3.Close()
        fileobj3.Close()

        Dim fileobj4 As FileStream = New FileStream("D:\New folder\sorted.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim strobj4 As New StreamWriter(fileobj4)
        Dim sort As student() = New student(noOfst) {}

        For i = 1 To noOfst
            For j = i + 1 To noOfst
                If stu(i).year < stu(j).year Then
                    sort(i) = New student
                    sort(i).year = stu(i).year
                    sort(i).id = stu(i).id
                    sort(i).name = stu(i).name
                    sort(i).department = stu(i).department
                    sort(i).CollegeName = stu(i).CollegeName
                    sort(i).sportdetails = spo(j).sportdetails
                    strobj4.Write("{0}  {1}  {2}  {3}  {4}  {5} ", sort(i).year, sort(i).id, sort(i).name, sort(i).department, sort(i).CollegeName, sort(i).sportdetails)
                    strobj4.WriteLine()
                End If
            Next
        Next

        strobj4.Close()
        fileobj4.Close()
    End Sub
End Module