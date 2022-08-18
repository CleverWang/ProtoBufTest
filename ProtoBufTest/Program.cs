namespace ProtoBufTest
{
    using Google.Protobuf;
    using ProtoBufTest.ProtoBuf;

    internal class Program
    {
        static void Main(string[] args)
        {
            var helloWorld = new HelloWorld()
            {
                Message = "Hello World!"
            };
            var helloProtoBuf = new HelloProtoBuf()
            {
                Message = "Hello ProtoBuf!"
            };

            Console.WriteLine($"helloWorld: {helloWorld}");
            Console.WriteLine($"helloProtoBuf: {helloProtoBuf}");

            using (var stream = new FileStream("HelloWorld.dat", FileMode.OpenOrCreate))
            {
                helloWorld.WriteTo(stream);

                stream.Seek(0, SeekOrigin.Begin);

                var helloWorldFromStream = HelloWorld.Parser.ParseFrom(stream);
                Console.WriteLine($"helloWorldFromStream: {helloWorldFromStream}");
            }

            using (var stream = new FileStream("HelloProtoBuf.dat", FileMode.OpenOrCreate))
            {
                helloProtoBuf.WriteTo(stream);

                stream.Seek(0, SeekOrigin.Begin);

                var helloProtoBufFromStream = HelloWorld.Parser.ParseFrom(stream);
                Console.WriteLine($"helloProtoBufFromStream: {helloProtoBufFromStream}");
            }
        }
    }
}