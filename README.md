# Kolos_template

# Ustawienia projektu
### Project type: Web
### Template: WebApi
### Advanced Settings: UseControllers

# Nuget
## Wszystkie muszą matchować wersję dotnet'a
Microsoft.AspNetCore.OpenApi
Microsoft.EntityFrameworkCore.Desing
Microsoft.EntityFrameworkCore.SqlServer
Swashbuckle.AspNetCore.SwaggerUI

# Zmienne:
[Key] --> zmienna jest kluczem \
[Column(TypeName = "char(10)")] --> kolumna typu varchar(długość) \
[ForeignKey(nameof(zmienna))] --> klucz obcy, nameof(nazwa zmiennej która nim jest) \
[MaxLength(300)] --> odnośnie stringa, podaje jego długość \
[PrimaryKey(nameof(PcId), nameof(ComponentCode))] --> klucze obce, w () nazwy zmiennych tych kluczy, dajemy nad deklaracją klasy
[Column(TypeName = "datetime")] --> kolumna typu datetime
[Column(TypeName = "float(5,2)")] --> float, pierwsza liczba to długość liczby, druga to dokładność po przecinku

# Model:
## Atrybuty:
odwzorować 1:1, referencje robi się inaczej \
kluczom dajemy "= null!" \
listy inicjujemy "= []" 

## Referencje:
tworzy się je za pomocą asocjacji, poprzez deklarowanie ich jako zmienne typu klasy do której je łączymy
po stronie pojedynczej kreski na diagramie jest lista IEnumerable<klasa>, \
po stronie wielu kresek jest pojedynczy atrybut \

# Database context w Infrastructure:
## Przykładowo:
```
public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    //tutaj dodajemy tabele wszystkich klas jake tworzymy dla modelu
    public DbSet<Komponent> Components { get; set; } 
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; } 
    public DbSet<ComponentTypes> ComponentTypes { get; set; } 
    public DbSet<PCs> PCs { get; set; }
    public DbSet<PcComponents> PcComponents { get; set; }

    //tutaj dodajemy jakieś wartości które znajdą się w bazie przy jej tworzeniu
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PCs>().HasData([
            new PCs { Id = 1, Name = "ROG Strix", Warranty = 5, Weight = 10.5f, CreatedAt = DateTime.Now, PcComponents = {}, Stock = 10},
            new PCs { Id = 2, Name = "ROG Strix", Warranty = 5, Weight = 9.5f, CreatedAt = DateTime.Now, PcComponents = {}, Stock = 9},
            new PCs { Id = 3, Name = "ROG Strix", Warranty = 5, Weight = 8.5f, CreatedAt = DateTime.Now, PcComponents = {}, Stock = 8}
        ]);
    }
}
```


# Program.cs
## dodać:
```
builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    //"default" jest referencją do zmiennej do connection stringa
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    //dodać jeżeli są błędy w migracji -- supresuje je
    opt.ConfigureWarnings(w =>
    w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
}); \
```

"default" dodajemy w *appsettings.json* jako:
"ConnectionStrings": {
    "Default": "Data Source=localhost, 1433; User=SA; Password=YourStrongPassword123!; Initial Catalog=master; Integrated Security=False;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False "
} \
pod "AllowedHosts"

referecje dla servisów i klasy servisu: \
builder.Services.AddScoped<IPCService, PCService>();