using MyAttribute;

namespace MyLibrary
{
    /// <summary>
    /// Aggiungendo due nuovi metodi etichettati con l'attributo
    /// [ExecuteMe] (e lasciando il riferimento a questo progetto)
    /// il programma vede normalmente ed esegue i due nuovi metodi,
    /// stampando correttamente l'output.
    ///
    /// Rimuovendo il riferimento all'assembly e cancellando i due nuovi metodi
    /// si nota che durante l'esecuzione vengono nuovamente eseguiti con i rispettivi
    /// output.
    ///
    /// Questo è dovuto al fatto che il metodo .LoadFrom() vede che l'assembly
    /// già caricato ha la stessa identità di quello che vogliamo caricare noi,
    /// di conseguenza non vengono caricate le modifiche che potrebbero
    /// essere state effettuate sull'assembly. Per questo dobbiamo aggiungere
    /// il riferimento nuovamente prima di rimuoverlo
    /// </summary>
   public class Foo 
    {
        [ExecuteMe]
        public void M1()
        {
            Console.WriteLine("M1()");
        }

        [ExecuteMe(45)]
        [ExecuteMe(0)]
        [ExecuteMe(3)]
        public void M2(int a)
        {
            Console.WriteLine($"M2() {nameof(a)}={a}");
        }

        [ExecuteMe("hello", "reflection")]
        public void M3(string first, string second)
        {
            Console.WriteLine($"M3() {nameof(first)} = {first}, {nameof(second)} = {second}");
        }
    }

    public class Foo2
    {
        public Foo2(int x) { }

        [ExecuteMe]
        public void M1()
        {
            Console.WriteLine($"{nameof(Foo2)}_M1()");
        }
    }

    public class Foo3
    {
        [ExecuteMe]
        public void M1()
        {
            Console.WriteLine($"{nameof(Foo3)}_M1()");
        }
    }
}