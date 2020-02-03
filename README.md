<p align="center">
  <a href="" rel="noopener">
 <img width=200px height=200px src="https://i.imgur.com/6wj0hh6.jpg" alt="Project logo"></a>
</p>

<h3 align="center">Point of Sales</h3>
<div align="center">

  [![Status](https://img.shields.io/badge/status-active-success.svg)]() 
  [![License](https://img.shields.io/badge/license-MIT-blue.svg)](/LICENSE)

</div>

---

<p align="center"> A point of sales desktop application for retail store
    <br> 
</p>

## 📝 Table of Contents
- [About](#about)
- [Getting Started](#getting_started)
- [Built Using](#built_using)
- [TODO](#todo)
- [Contributing](../CONTRIBUTING.md)
- [Authors](#authors)
- [Acknowledgments](#acknowledgement)

## 🧐 About <a name = "about"></a>
On my final year in University developed a poisnt of sales system as an assignment. 

I developed it while I was still learning C# and WPF so there's a lot to improve.

It has a cashier interface where a cashier can login and can products and the system will to all the calculation and store all the important information and print a pdf reciept. 

It also has an admin interface where an admin (manager) can view stock, add new products, see which stock is out and the system has ordered, update product, catergory and supplier information.

## 🏁 Getting Started <a name = "getting_started"></a>
I'm planning to implement sqlite as the database so it can be fully independent.

For now you can clone the repository and compile the project in visual studio to run it. It will need to connect to the [tux-shop-api](https://github.com/mkhululiNikani/tuxshop-rest-api) rest api though, you can clone it and run it on localhost too. 

### Prerequisites
Until I implement SQLite, you need the rest api for the project. (contributions are welcome)

```
tux-shop-api
```

##  TODO<a name = "todo"></a>

- [ ] Add SQLite support
- [ ] Build v1.0 Release
- [ ] Add search feature for Admin
- [ ] Clean Code

## ⛏️ Built Using <a name = "built_using"></a>

- [WPF]( https://docs.microsoft.com/en-us/dotnet/framework/wpf/ ) - Front-end
- [C#]( https://docs.microsoft.com/en-us/dotnet/csharp/ ) - Back-end
- [Mysql](https://mysql.com) - Database
- [PHP](https://php.net) - API

## ✍️ Authors <a name = "authors"></a>
- [mkhululi](https://mkhululi.net/) - Idea & All the work

## 🎉 Acknowledgements <a name = "acknowledgement"></a>
- Google Material Design
