select c.ClientId,c.Nickname,c.Password,cp.Age,cp.Sex,cp.ActivityLevel,r.NameRole
from Clients c 
left join ClientProfiles cp on cp.ClientId=c.ClientId 
left join ClientRoles cr on cr.ClientId=c.ClientId 
left join Roles r on r.Id=cr.RoleId

delete from Clients where ClientId=8