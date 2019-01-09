<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// Define other methods and classes here
// Type Class (System) <http://msdn.microsoft.com/en-us/library/system.type(v=vs.110).aspx>


    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
    }

    public class NameEntity : EntityBase
    {
        public string Name { get; private set; }

        public NameEntity(string name)
        {
            Name = name;
        }
    }

    public class OtherEntity : EntityBase
    {
        public string Other { get; private set; }

        public OtherEntity(string name)
        {
            Other = name;
        }
    }

    public static class ETiMoreOnExtensions
    {
        public static void ScreenDump(this System.Reflection.MemberInfo[] memberInfos, string label)
        {
            foreach (var info in memberInfos)
            {
                Console.WriteLine("\t{0}: {1}", label, info.Name);
            }
        }
    }

        public static void ExamineObject(object entity)
        {
            Type type = entity.GetType();
            Console.WriteLine("Type: {0}", type.Name);

            PropertyInfo[] properties = type.GetProperties();
            properties.ToList().ForEach(prop => Console.WriteLine("\tProp: {0} : {1}", prop.Name, prop.GetValue(entity).ToString()));
            properties.ScreenDump("Property");

            MethodInfo[] methods = type.GetMethods();
            methods.ScreenDump("Method");

            FieldInfo[] fields = type.GetFields();
            fields.ScreenDump("Field");
        }

        static void Main(string[] args)
        {
            ExamineObject( new OtherEntity("bob"));
            ExamineObject(new NameEntity("bob"));
        }
