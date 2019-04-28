<Query Kind="Program" />

void Main()
{
	var userAuthDtos =  new List<UserAuthDto>( new []{ 
		new UserAuthDto(1, 101),
		new UserAuthDto(1, 102),
		new UserAuthDto(1, 103),
		new UserAuthDto(2, 101),
		new UserAuthDto(2, 103),
		new UserAuthDto(2, 105),
		new UserAuthDto(3, 101),
		new UserAuthDto(3, 102),
		new UserAuthDto(3, 104)
	});

	var uadGroup = userAuthDtos.GroupBy(uad => uad.UserId);
	var userAuths = uadGroup.Select(uadg => 
		new UserAuths( uadg.Key, uadg.Select(uado => uado.Auth) ) );

	foreach(var userAuth in userAuths) {
		var auths = String.Join(", ", userAuth.Auths.Select(au => au.ToString()));
		Console.WriteLine($"User Auth: {userAuth.UserId} {auths} ");
	}
}

// Define other methods and classes here
class UserAuthDto {
	public int UserId { get; }
	public int Auth { get; }
	
	public UserAuthDto(int userId, int auth) {
		UserId = userId;
		Auth = auth;
	}
}	

class UserAuths {
	public int UserId { get; }
	public IReadOnlyCollection<int> Auths { get; }

	public bool HasAuth(int auth) => Auths.Contains(auth);

	public UserAuths(int userId, IEnumerable<int> auths) {
		UserId = userId;
		Auths = auths.ToList();
	}
}