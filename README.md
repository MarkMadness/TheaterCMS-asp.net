# TheaterCMS-asp.net

At Prosper IT Consulting, one project I worked on was a redesign for a theater company in Oregon. Our team was given references of other websites as a guide for designing the 
style and our project lead breaking down the project into user stories, individual tasks we each took on. We worked in a remote work environment using the Agile/Scrum 
methodology.

## Home Page

Completely from scratch, I took on the first task of designing the homepage adn eestablishing the color palette for the site as a whole. I setup sections for each part of the
home page featuring a sliding carousel, grid content for future shows, and a short paragraph section about the company. I also contributed to the styling of the navbar that 
another teammate was working on.

![](https://github.com/MarkMadness/TheaterCMS-asp.net/blob/main/showcase/After_Navbar_2.jpg)

  <nav class="palette-navbar navbar fixed-top navbar-expand-lg navbar-light" id="menu">
          <a class="navbar-brand palette-navbar-header" href="@Url.Action("Index", "Home")">
              <img class="logoImg" src="~/Content/Images/cropped-logo.png" id="logo" />
          </a>
          <!--Drop down menu button -->
          <button class="navbar-toggler bg-light" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
              <span class="navbar-toggler-icon"></span>
          </button>

          <div class="collapse navbar-collapse" id="navbarSupportedContent">
              <ul class="navbar-nav mr-auto">
                  <!--Events-->
                  <li class="nav-item dropdown">
                      <a class="nav-button dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                          Events
                      </a>
                      <ul class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                          <li class="dropdown-submenu">
                              <a class="dropdown-item dropdown-toggle" href="@Url.Action("Index", "Productions")">Productions</a>
                              <ul class="dropdown-menu">
                                  <li><a class="dropdown-item" href="@Url.Action("Index", "Productions")">All</a></li>
                                  <li><a class="dropdown-item" href="@Url.Action("Current", "Productions")">Current</a></li>
                              </ul>
                          </li>
                          <li><a class="dropdown-item" href="@Url.Action("Index", "CalendarEvents")">Calendar of Events</a></li>
                          <li><a class="dropdown-item" href="@Url.Action("Create", "RentalRequest")">Rentals</a></li>
                      </ul>
                  </li>
                  <!--Company-->
                  <li class="nav-item dropdown">
                      <a class="nav-button dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                          Company
                      </a>
                      <ul class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                          <li><a class="dropdown-item" href="@Url.Action("About", "Home")">About</a></li>
                          <li><a class="dropdown-item" href="@Url.Action("Archive", "Home")">Archive Dashboard</a></li>
                          <li><a class="dropdown-item" href="@Url.Action("Index", "CastMembers")">Current Members</a></li>
                      </ul>
                  </li>

## Table Styling

My next task was to polish the styling of the table elements on a number of pages with rendered data from the sql database. Since the previous developer who worked on the table
used bootstrap I didn't want to mess up what they established, I created classes for each of the table's tag elements in order to style those individual elements of the table.

### Before

![](https://github.com/MarkMadness/TheaterCMS-asp.net/blob/main/showcase/03_Before.jpg)

### After

![](https://github.com/MarkMadness/TheaterCMS-asp.net/blob/main/showcase/03_After.jpg)

  .table-styling, .th-styling, .td-styling, .tr-styling {
      border: 2px solid var(--light-color);
  }

  .table-styling {
      width: 100%;
  }

  .th-styling {
      background-color: var(--secondary-color);
      color: var(--dark-color);
      padding: 8px;
      font-size: 18px;
  }

  .td-styling {
      background-color: var(--dark-color);
      color: var(--light-color);
      padding: 4px;
  }

  .td-styling:hover {
      background-color: var(--main-secondary-color);
      color: var(--dark-color);
  }

### Before
![](https://github.com/MarkMadness/TheaterCMS-asp.net/blob/master/TheaterCMS/03_Before.jpg)

### After
![](https://github.com/MarkMadness/TheaterCMS-asp.net/blob/master/TheaterCMS/03_After.jpg)


## Cast Member page
With Admin access, the user can add, edit, or delete profiles for cast members, content section, image section, and current production. Each of these view folders had an index, create, edit, 
and delete page. Very similar to the table styling I edited I designed how the inputbox options looked in a more appealing way on the Create page. 

### Before
![](https://github.com/MarkMadness/TheaterCMS-asp.net/blob/master/TheaterCMS/04_ContentSection_Create_Before.jpg)
![](https://github.com/MarkMadness/TheaterCMS-asp.net/blob/master/TheaterCMS/04_ContentSection_Edit_Before.jpg)
![](https://github.com/MarkMadness/TheaterCMS-asp.net/blob/master/TheaterCMS/04_DisplayInfo_Create_Before.jpg)

### After
![](https://github.com/MarkMadness/TheaterCMS-asp.net/blob/master/TheaterCMS/04_ContentSection_Create_After.jpg)
![](https://github.com/MarkMadness/TheaterCMS-asp.net/blob/master/TheaterCMS/04_ContentSection_Edit_After.jpg)
![](https://github.com/MarkMadness/TheaterCMS-asp.net/blob/master/TheaterCMS/04_DisplayInfo_Create_After.jpg)


## Revise Navbar
During the time I worked on the table styling and the design for Create, Edit, and Delete pages someone set up a navbar, but it seemed basic and didn't match the theme of the 
site. I volunteered to tweek the navbar so the colors, hover effects, and text size felt more in tune with the theme of the website.

### Before
![](https://github.com/MarkMadness/TheaterCMS-asp.net/blob/master/TheaterCMS/Before_Navbar.jpg)

### After
![](https://github.com/MarkMadness/TheaterCMS-asp.net/blob/master/TheaterCMS/After_Navbar_1.jpg)
![](https://github.com/MarkMadness/TheaterCMS-asp.net/blob/master/TheaterCMS/After_Navbar_2.jpg)


 
