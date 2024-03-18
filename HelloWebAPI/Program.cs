var builder = WebApplication.CreateBuilder(args);
//Service (container)

builder.Services.AddControllers(); // controlleri kullanacağım.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //swagger'ı kullanacağım. paketlerden yükledim. çünkü boş bir şablon oluşturduk.biz dolduruyoruz öğrenmek için.





var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // burada da yukarıda tanımladıklarımı kullan dedim.
    app.UseSwaggerUI(); // ayrıca launch setting.json'a giderek  "launchUrl": "swagger", bu kodu ekledim ki direkt swagger açılsın.
}


app.MapControllers();


app.Run();

