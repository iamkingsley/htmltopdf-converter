# HTML to PDF Converter app.

## Stack

Server - .Net 8  
Client - React + TypeScript (using vite)

## How to run this app

#### Running the Server

cd sever && cd src
dotnet restore  
dotnet run --project Presentation/HTMLToPDFConvertor.Api/HTMLToPDFConvertor.Api.csproj

NB: ensure it runs using the https launch settings profile. Else it will use a different port number other than the one the client is using.

#### Running the client 

cd client    
npm install  
npm run dev
