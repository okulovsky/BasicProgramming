
using System;
using System.Threading;
delegate void MyAction(ref int value);
using Student=Slide02.Student;

class Program
{
    static void Main()
    {
        var s=new Student[2];
        s[0]=new Student();
        s[0].FirstName="John";
        s[0].Age=18;
    }
}
