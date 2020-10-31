Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Globalization

Public Class hltvOvDesc
    Public Structure stHltvOvDesc
        Dim mapName As String
        Dim material As String
        Dim pos_x As Integer
        Dim pos_y As Integer
        Dim scale As Double
        Dim rotate As Double
        Dim zoom As Double
        Dim CTSpawn_x As Double
        Dim CTSpawn_y As Double
        Dim TSpawn_x As Double
        Dim TSpawn_y As Double
        Dim bombA_x As Double
        Dim bombA_y As Double
        Dim bombB_x As Double
        Dim bombB_y As Double
        Dim verticalsections_Default_AltitudeMax As Integer
        Dim verticalsections_Default_AltitudeMin As Integer
        Dim verticalsections_Lower_AltitudeMax As Integer
        Dim verticalsections_Lower_AltitudeMin As Integer
    End Structure

    Public Shared Function getValue(input As String)
        Return input.Split("""")(3)
    End Function

    Public Shared Function parse(filepath As String) As stHltvOvDesc
        Dim lines As String() = File.ReadAllLines(filepath)

        Dim resItems As New stHltvOvDesc

        For Each s As String In lines
            If s = Nothing Or s = "" Then Continue For

            s.Replace(" ", "")
            s.Replace(vbCrLf, "")
            s.Replace(vbNewLine, "")

            s = Regex.Replace(s, "\s+", "")

            If s.StartsWith("//") Then Continue For

            If s.StartsWith("""material""") Then resItems.material = getValue(s)
            If s.StartsWith("""pos_x""") Then resItems.pos_x = Int(getValue(s))
            If s.StartsWith("""pos_y""") Then resItems.pos_y = Int(getValue(s))
            If s.StartsWith("""scale""") Then resItems.scale = Double.Parse(getValue(s), CultureInfo.InvariantCulture)
            If s.StartsWith("""rotate""") Then resItems.rotate = Double.Parse(getValue(s), CultureInfo.InvariantCulture)
            If s.StartsWith("""zoom""") Then resItems.zoom = Double.Parse(getValue(s), CultureInfo.InvariantCulture)
            If s.StartsWith("""CTSpawn_x""") Then resItems.CTSpawn_x = Double.Parse(getValue(s), CultureInfo.InvariantCulture)
            If s.StartsWith("""CTSpawn_y""") Then resItems.CTSpawn_y = Double.Parse(getValue(s), CultureInfo.InvariantCulture)
            If s.StartsWith("""TSpawn_x""") Then resItems.TSpawn_x = Double.Parse(getValue(s), CultureInfo.InvariantCulture)
            If s.StartsWith("""TSpawn_y""") Then resItems.TSpawn_y = Double.Parse(getValue(s), CultureInfo.InvariantCulture)
            If s.StartsWith("""bombA_x""") Then resItems.bombA_x = Double.Parse(getValue(s), CultureInfo.InvariantCulture)
            If s.StartsWith("""bombA_y""") Then resItems.bombA_y = Double.Parse(getValue(s), CultureInfo.InvariantCulture)
            If s.StartsWith("""bombB_x""") Then resItems.bombB_x = Double.Parse(getValue(s), CultureInfo.InvariantCulture)
            If s.StartsWith("""bombB_y""") Then resItems.bombB_y = Double.Parse(getValue(s), CultureInfo.InvariantCulture)
        Next

        Return resItems
    End Function
End Class