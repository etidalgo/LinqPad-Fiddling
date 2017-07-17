<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here

    public enum Role
    {
        None = 0,
        Carrier = 1,
        CarrierSpectator = 2,
        DeliveryPoint = 3,
        ManagerSpectatorOutwardsGoods = 4,
        Owner = 5,
        PickupPoint = 6,
        ManagerSpectatorInwardsGoods = 7,
        CarrierDepot = 8,
        SoldToParty = 9,
        DivisionManagerInwards = 10,
        DivisionManagerOutwards = 11,
        Receiver = 12,
        Containers = 13,
        ShippingLine = 14,
        Lodestar = 15,
        Shipping = 16,
        LogisticsProvider = 17,
        SourcePlant = 18,
        CreatedBy = 19,
        CoastalShipping = 20,
    }
	
	public Dictionary<Role, IEnumerable<Role>> RolesOfInterestByRole2 =
		new Dictionary<Role, IEnumerable<Role>>(){
			{ Role.Carrier, new Role[]{ Role.CarrierSpectator } },
			{ Role.DeliveryPoint, new Role[]{ Role.ManagerSpectatorInwardsGoods, Role.DivisionManagerInwards } }
			{ Role.PickupPoint, new Role[]{ Role.ManagerSpectatorOutwardsGoods, Role.DivisionManagerOutwards } }
	};
	
	// Source: [vsp_object_partner_add]
	
	public Dictionary<Role, Role[]> RolesOfInterestByRole =
		new Dictionary<Role, Role[]>(){
			{ Role.Carrier, new Role[]{ Role.CarrierSpectator } },
			{ Role.DeliveryPoint, new Role[]{ Role.ManagerSpectatorInwardsGoods, Role.DivisionManagerInwards } }
			{ Role.PickupPoint, new Role[]{ Role.ManagerSpectatorOutwardsGoods, Role.DivisionManagerOutwards } }
	};
	// Source: [vsp_object_partner_add]
	