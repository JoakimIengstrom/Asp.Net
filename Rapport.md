# Rapport

### Vidareutveckling 

Jag är väldigt nöjd med UXen för sidan, den känns lättsam och enkel, all desing är inte perfekt, men funkar bra på flera olika skärmar. Det är ganska lätt att bygga ut med fler views och razorpages om man vill. Däremot något som ligger på TODO är att göra så att den inte nollar databasen varje gång utan sedan går att fortsätta på. 

Sedan valde jag ju att lägga på flera roller istället för att ta bort den och lägga till en ny. Varför? Jadu, det gjorde jag för att jag ville se hur det kan fungera och för att jag inte hunnit göra metoder som kanske stryker events från en attendee som förvandlas till en organizer.

---
### Säkerhet

Använde ju följade kod för att "stänga" ner sidan och sedan sätta Authorizon där jag vill ha det och styra behörigheterna. Jag tänker att för detta ändamålet är det tillräckligt, men finns med största sannorlikhet andra saker att skydda sig mot som jag inte har jobbat med. 

Som nämndes i utvecklingsdelen så är det kanske lite farligt att lägga på flera roller på en och samma user, mest för att det kan bli problem om t ex en organizer bokar sig till ett event. Hur det skall hanteras hade ju fått lösas genom att diskutera behovet och syftet med att var en viss typ av User. 

Att jag har lagt behörigheter gör ju också att en besökare inte kan råka skriva en URL som gör att de hamnar på en sida de inte bör kunna se. 

```Csharp

  builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

```  

---
###### Inloggningar

##### Users   
```Csharp

     List<EventiaUser> attendees = new List<EventiaUser>
            {
                new() {UserName = "Attendee1",OrganizerApplication = false},
                new() {UserName = "Attendee2",OrganizerApplication = false},
                new() {UserName = "Attendee3",OrganizerApplication = true},

                new() {UserName = "Admin", FirstName = "Johan", OrganizerApplication = false}
            };

            foreach (var attendee in attendees)
            {
                await _userManager.CreateAsync(attendee, password: "Qwerty87!"); 
            };
    }
```    

##### Organizers    
```Csharp

    List<EventiaUser> organizers = new List<EventiaUser>
            {
                new() {UserName = "Organizer1"},
                new() {UserName = "Organizer2"},
                new() {UserName = "Organizer3"}
            };

            foreach (var organizer in organizers)
            {
                await _userManager.CreateAsync(organizer, password: "Qwerty87!");
            };
    }
```
Sätter roller
```Csharp

            await _roleManager.CreateAsync(new IdentityRole { Name = "UserAdmin" });
            await _roleManager.CreateAsync(new IdentityRole { Name = "UserOrganizer" });
            await _roleManager.CreateAsync(new IdentityRole { Name = "UserAttendee" });

            await _userManager.AddToRoleAsync(attendees[0], "UserAttendee");
            await _userManager.AddToRoleAsync(attendees[1], "UserAttendee");
            await _userManager.AddToRoleAsync(attendees[2], "UserAttendee");

            await _userManager.AddToRoleAsync(attendees[3], "UserAdmin");

            await _userManager.AddToRoleAsync(organizers[0], "UserOrganizer");
            await _userManager.AddToRoleAsync(organizers[1], "UserOrganizer");
            await _userManager.AddToRoleAsync(organizers[2], "UserOrganizer");
    }
```


