<Query Kind="Program" />

void Main()
{
	var groupBuilder = 
		new GroupBuilder("Group Name")
			.WithSection("Section Alpha")
				.WithItem("Item A", 1001)
				.WithItem("Item B", 1002)
			.WithSection("Section Two")
				.WithItem("Item 2A", 2001)
				.WithItem("Item 2B", 2002)
			.WithSection("Section Three")
				.WithItem("Item 46A", 3001)
				.WithItem("Item 4B", 3002);
			
	var group = groupBuilder.Build();
	
	DumpGroup(group);
}

public void DumpGroup(Group group) {
	Console.WriteLine($"{group.Name}");
	group.Sections.ToList().ForEach(section => DumpSection(section));
}

public void DumpSection(Section section) {
	Console.WriteLine($"  {section.Name}");
	section.Items.ToList().ForEach(item => DumpItem(item));
}

public void DumpItem(Item item) {
	Console.WriteLine($"    {item.Name}:{item.Code}");
}

// Define other methods and classes here
public class Item {
	public string Name { get; }
	public int Code { get; }
	public Item(string name, int code) {
		Name = name;
		Code = code;
	}
}

public class Section {
	public string Name { get; }
	public IEnumerable<Item> Items { get; }
	
	public Section(string name, IEnumerable<Item> items) {
		Name = name;
		Items = items;
	}
}

public class Group {
	public string Name { get; }
	public IEnumerable<Section> Sections { get; }

	public Group(string name, IEnumerable<Section> sections) {
		Name = name;
		Sections = sections;
	}
}

public class GroupBuilder {
	string _name { get; }
	string _currentSectionName { get; set; }
	List<Section> _sections { get; set; }
	List<Item> _items { get; set; }
	
	public GroupBuilder(string name) {
		_name = name;
		_currentSectionName = String.Empty;
		_sections = new List<Section>();
		_items = new List<Item>();
	}
	
	public GroupBuilder WithSection(string name) {
		BuildCurrentSectionIfAny();
		_currentSectionName = name;
		return this;
	}

	public GroupBuilder WithItem(string name, int code) {
		_items.Add(new Item(name, code));
		return this;
	}
	
	public Group Build() {
		BuildCurrentSectionIfAny();
		return new Group(_name, _sections);
	}
	
	void BuildCurrentSectionIfAny() {
		if (!String.IsNullOrEmpty(_currentSectionName)) {
			_sections.Add(new Section(_currentSectionName, _items));
		}
		_currentSectionName = String.Empty;
		_items = new List<Item>();
	}
}