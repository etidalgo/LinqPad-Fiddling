<Query Kind="Program" />

// yield break should allow SelectMany to continue
void Main()
{
	var allEnumerators = new List<SimpleEnumerator>{ new Omega(), new Gamma(), new Alpha(), new Beta(), new Epsilon() };
	var allNumbers = allEnumerators.SelectMany(ae => ae.Next());
	allNumbers.Dump();
}

// Define other methods and classes here
public interface SimpleEnumerator {
	IEnumerable<int> Next();
}

public class Omega : SimpleEnumerator {
	public IEnumerable<int> Next(){
		yield break;
	}
}

public class Gamma : SimpleEnumerator {
	public IEnumerable<int> Next(){
		if(false){
			yield break;
		}
	}
}

public class Epsilon : SimpleEnumerator {
	public IEnumerable<int> Next(){
		throw new NotImplementedException();
	}
}

public class Alpha : SimpleEnumerator {
	public IEnumerable<int> Next(){
		yield return 1;
		yield return 4;
		yield return 16;
		// yield break;
	}
}

public class Beta : SimpleEnumerator {
	public IEnumerable<int> Next(){
		yield return 3;
		yield return 9;
		yield break;
	}
}


