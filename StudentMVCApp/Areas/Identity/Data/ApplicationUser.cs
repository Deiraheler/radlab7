using Microsoft.AspNetCore.Identity;

namespace StudentMVCAppNew.Data;

public class ApplicationUser : IdentityUser
{
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Age { get; set; }
    public string Nationality { get; set; }
}