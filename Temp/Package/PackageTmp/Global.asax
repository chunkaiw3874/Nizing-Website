<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs
    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
    }

    void RegisterRoutes(RouteCollection routes)
    {
        //fixes broken ajax
        routes.Ignore("{resource}.axd/{*pathInfo}");
        //legacy en routing
        routes.MapPageRoute("", "legacy/{page}", "~/en/{page}.aspx");

        //current page routes
        routes.MapPageRoute("", "{language}/product/product-not-found", "~/product-not-found.aspx");
        routes.MapPageRoute("", "page-not-found", "~/page-not-found.aspx");

        //routes.MapPageRoute("", "", "~/default.aspx");
        //routes.MapPageRoute("", "default", "~/default.aspx");
        routes.MapPageRoute("", "{language}", "~/default.aspx", true,
            new RouteValueDictionary { { "language", "" } },
            new RouteValueDictionary { { "language", "^zh$|^en$" } }
            );

        routes.MapPageRoute("", "{language}/company/intro", "~/company-intro.aspx");
        routes.MapPageRoute("", "{language}/company-intro", "~/company-intro.aspx");
        routes.MapPageRoute("", "{language}/company/culture", "~/company-culture.aspx");
        routes.MapPageRoute("", "{language}/company/history", "~/company-history.aspx");
        routes.MapPageRoute("", "{language}/company/capability", "~/company-capability.aspx");
        routes.MapPageRoute("", "{language}/company/lab", "~/company-lab.aspx");

        routes.MapPageRoute("", "{language}/product", "~/product.aspx");
        routes.MapPageRoute("", "{language}/product/silicone-fiberglass-wire", "~/silicone-fiberglass-wire.aspx");
        routes.MapPageRoute("", "{language}/product/high-temperature-wire", "~/high-temperature-wire.aspx");
        routes.MapPageRoute("", "{language}/product/silicone-wire", "~/silicone-wire.aspx");
        routes.MapPageRoute("", "{language}/product/pvc-wire", "~/pvc-wire.aspx");
        routes.MapPageRoute("", "{language}/product/teflon-wire", "~/teflon-wire.aspx");
        routes.MapPageRoute("", "{language}/product/xlpe-wire", "~/xlpe-wire.aspx");
        routes.MapPageRoute("", "{language}/product/tube", "~/tube.aspx");
        routes.MapPageRoute("", "{language}/product/thermocouple", "~/thermocouple.aspx");
        routes.MapPageRoute("", "{language}/product/heating-wire", "~/heating-wire.aspx");
        routes.MapPageRoute("", "{language}/product/automobile-wire", "~/automobile-wire.aspx");
        routes.MapPageRoute("", "{language}/product/military-grade-wire", "~/military-grade-wire.aspx");
        routes.MapPageRoute("", "{language}/product/composite-cable", "~/composite-cable.aspx");
        routes.MapPageRoute("", "{language}/product/anti-refrigerant-wire", "~/anti-refrigerant-wire.aspx");
        routes.MapPageRoute("", "{language}/product-profile/{product-category}/{productID}", "~/product-profile.aspx");
        routes.MapPageRoute("", "{language}/product/{product-category}/{productID}", "~/product-profile.aspx");

        routes.MapPageRoute("", "{language}/application", "~/application.aspx");

        routes.MapPageRoute("", "{language}/application/{application}", "~/application-list.aspx");

        routes.MapPageRoute("", "{language}/application/{application}/motor-temperature-sensor-cable-tesla-taycan", "~/application/motor-temperature-sensor-cable-tesla-taycan.aspx");
        routes.MapPageRoute("", "{language}/application/{application}/motor-power-cable", "~/application/motor-power-cable.aspx");
        routes.MapPageRoute("", "{language}/application/{application}/fighter-jet-temperature-sensor-cable", "~/application/fighter-jet-temperature-sensor-cable.aspx");
        routes.MapPageRoute("", "{language}/application/{application}/inflammable-signal-cable", "~/application/inflammable-signal-cable.aspx");
        routes.MapPageRoute("", "{language}/application/{application}/electrosurgical-unit-cable", "~/application/electrosurgical-unit-cable.aspx");
        routes.MapPageRoute("", "{language}/application/{application}/submarine-communications-cable", "~/application/submarine-communications-cable.aspx");
        routes.MapPageRoute("", "{language}/application/{application}/multi-furnace-temperature-control-dual-shielded-cable", "~/application/multi-furnace-temperature-control-dual-shielded-cable.aspx");
        routes.MapPageRoute("", "{language}/application/{application}/high-voltage-ignition-wire", "~/application/high-voltage-ignition-wire.aspx");
        routes.MapPageRoute("", "{language}/application/{application}/high-frequency-communication-cable", "~/application/high-frequency-communication-cable.aspx");
        routes.MapPageRoute("", "{language}/application/{application}/military-spec-missile-control-cable", "~/application/military-spec-missile-control-cable.aspx");
        routes.MapPageRoute("", "{language}/application/{application}/military-spec-submarine-cable", "~/application/military-spec-submarine-cable.aspx");
        routes.MapPageRoute("", "{language}/application/{application}/military-spec-high-frequency-transmission-control-cable", "~/application/military-spec-high-frequency-transmission-control-cable.aspx");
        routes.MapPageRoute("", "{language}/application/{application}/military-spec-signal-control-cable", "~/application/military-spec-signal-control-cable.aspx");
        routes.MapPageRoute("", "{language}/application/{application}/dual-insulation-high-voltage-silicone-wire", "~/application/dual-insulation-high-voltage-silicone-wire.aspx");


        routes.MapPageRoute("", "{language}/material", "~/material.aspx");
        routes.MapPageRoute("", "{language}/material/conductor", "~/conductor-category.aspx");
        routes.MapPageRoute("", "{language}/material/conductor/copper", "~/copper.aspx");
        routes.MapPageRoute("", "{language}/material/conductor/silver-copper-alloy", "~/agcu.aspx");
        routes.MapPageRoute("", "{language}/material/conductor/tin-copper-alloy", "~/sncu.aspx");
        routes.MapPageRoute("", "{language}/material/conductor/nickel-copper-alloy", "~/nicu.aspx");
        routes.MapPageRoute("", "{language}/material/conductor/silver", "~/ag.aspx");
        routes.MapPageRoute("", "{language}/material/silicone", "~/silicone.aspx");
        routes.MapPageRoute("", "{language}/material/teflon", "~/teflon.aspx");
        routes.MapPageRoute("", "{language}/material/plastic", "~/plastic.aspx");
        routes.MapPageRoute("", "{language}/material/twinning", "~/twinning.aspx");
        routes.MapPageRoute("", "{language}/material/thermoplastic-elastomer", "~/thermoplastic-elastomer.aspx");

        routes.MapPageRoute("", "{language}/ulnumber", "~/ulnumber.aspx");

        routes.MapPageRoute("", "{language}/certificate", "~/certificate.aspx");
        routes.MapPageRoute("", "{language}/certificate/ul", "~/ul.aspx");
        routes.MapPageRoute("", "{language}/certificate/vde", "~/vde.aspx");

        routes.MapPageRoute("", "{language}/contact-us", "~/contact_us.aspx");
        routes.MapPageRoute("", "{language}/contact-us/job-listing", "~/job-listing.aspx");

        routes.MapPageRoute("", "{language}/declaration/conflict-free-mineral-declaration", "~/conflict-free-mineral-declaration.aspx");

        routes.MapPageRoute("", "{language}/portal", "~/portal.aspx");

        routes.MapPageRoute("", "{language}/sitemap", "~/sitemap.aspx");



        //seo old page routing to new page (has new page)
        routes.MapPageRoute("", "pdf/{filename}.pdf", "~/product-profile.aspx");
        routes.MapPageRoute("", "en/default", "~/default.aspx");
        //military-grade-wire
        routes.MapPageRoute("", "m16878", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "m16878" } });
        routes.MapPageRoute("", "en/m16878", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "m16878" } });
        routes.MapPageRoute("", "m16878.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "m16878" } });
        routes.MapPageRoute("", "en/m16878.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "m16878" } });
        routes.MapPageRoute("", "m22759", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "m22759" } });
        routes.MapPageRoute("", "en/m22759", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "m22759" } });
        routes.MapPageRoute("", "m22759.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "m22759" } });
        routes.MapPageRoute("", "en/m22759.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "m22759" } });
        routes.MapPageRoute("", "m24643", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "m24643" } });
        routes.MapPageRoute("", "en/m24643", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "m24643" } });
        routes.MapPageRoute("", "m24643.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "m24643" } });
        routes.MapPageRoute("", "en/m24643.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "m24643" } });
        routes.MapPageRoute("", "m27500", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "m27500" } });
        routes.MapPageRoute("", "en/m27500", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "m27500" } });
        routes.MapPageRoute("", "m27500.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "m27500" } });
        routes.MapPageRoute("", "en/m27500.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "m27500" } });
        routes.MapPageRoute("", "m81822", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "m81822" } });
        routes.MapPageRoute("", "en/m81822", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "m81822" } });
        routes.MapPageRoute("", "m81822.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "m81822" } });
        routes.MapPageRoute("", "en/m81822.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "m81822" } });
        //silicone-fiberglass-wire
        routes.MapPageRoute("", "rsge", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "RS-GE" } });
        routes.MapPageRoute("", "en/rsge", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "RS-GE" } });
        routes.MapPageRoute("", "rsge.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "RS-GE" } });
        routes.MapPageRoute("", "en/rsge.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "RS-GE" } });
        routes.MapPageRoute("", "tm3320", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "tm3320" } });
        routes.MapPageRoute("", "en/tm3320", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "tm3320" } });
        routes.MapPageRoute("", "tm3320.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "tm3320" } });
        routes.MapPageRoute("", "en/tm3320.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "tm3320" } });
        routes.MapPageRoute("", "ul3071", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3071" } });
        routes.MapPageRoute("", "en/ul3071", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3071" } });
        routes.MapPageRoute("", "ul3071.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3071" } });
        routes.MapPageRoute("", "en/ul3071.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3071" } });
        routes.MapPageRoute("", "ul3074", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3074" } });
        routes.MapPageRoute("", "en/ul3074", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3074" } });
        routes.MapPageRoute("", "ul3074.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3074" } });
        routes.MapPageRoute("", "en/ul3074.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3074" } });
        routes.MapPageRoute("", "ul3075", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3075" } });
        routes.MapPageRoute("", "en/ul3075", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3075" } });
        routes.MapPageRoute("", "ul3075.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3075" } });
        routes.MapPageRoute("", "en/ul3075.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3075" } });
        routes.MapPageRoute("", "ul3122", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3122" } });
        routes.MapPageRoute("", "en/ul3122", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3122" } });
        routes.MapPageRoute("", "ul3122.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3122" } });
        routes.MapPageRoute("", "en/ul3122.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3122" } });
        routes.MapPageRoute("", "ul3172", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3172" } });
        routes.MapPageRoute("", "en/ul3172", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3172" } });
        routes.MapPageRoute("", "ul3172.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3172" } });
        routes.MapPageRoute("", "en/ul3172.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3172" } });
        routes.MapPageRoute("", "ul3232", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3232" } });
        routes.MapPageRoute("", "en/ul3232", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3232" } });
        routes.MapPageRoute("", "ul3232.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3232" } });
        routes.MapPageRoute("", "en/ul3232.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3232" } });
        routes.MapPageRoute("", "ul3304", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3304" } });
        routes.MapPageRoute("", "en/ul3304", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3304" } });
        routes.MapPageRoute("", "ul3304.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3304" } });
        routes.MapPageRoute("", "en/ul3304.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3304" } });
        routes.MapPageRoute("", "ul3512", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3512" } });
        routes.MapPageRoute("", "en/ul3512", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3512" } });
        routes.MapPageRoute("", "ul3512.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3512" } });
        routes.MapPageRoute("", "en/ul3512.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3512" } });
        routes.MapPageRoute("", "ul3513", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3513" } });
        routes.MapPageRoute("", "en/ul3513", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3513" } });
        routes.MapPageRoute("", "ul3513.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3513" } });
        routes.MapPageRoute("", "en/ul3513.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3513" } });
        routes.MapPageRoute("", "ul3645", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3645" } });
        routes.MapPageRoute("", "en/ul3645", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3645" } });
        routes.MapPageRoute("", "ul3645.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3645" } });
        routes.MapPageRoute("", "en/ul3645.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3645" } });
        routes.MapPageRoute("", "vde-h05sj-k", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "vde-h05sj-k" } });
        routes.MapPageRoute("", "en/vde-h05sj-k", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "vde-h05sj-k" } });
        routes.MapPageRoute("", "vde-h05sj-k.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "vde-h05sj-k" } });
        routes.MapPageRoute("", "en/vde-h05sj-k.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "vde-h05sj-k" } });
        //high-temperature-wire
        routes.MapPageRoute("", "cf-750", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "cf-750" } });
        routes.MapPageRoute("", "en/cf-750", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "cf-750" } });
        routes.MapPageRoute("", "cf-750.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "cf-750" } });
        routes.MapPageRoute("", "en/cf-750.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "cf-750" } });
        routes.MapPageRoute("", "mg-5107", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "mg-5107" } });
        routes.MapPageRoute("", "en/mg-5107", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "mg-5107" } });
        routes.MapPageRoute("", "mg-5107.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "mg-5107" } });
        routes.MapPageRoute("", "en/mg-5107.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "mg-5107" } });
        routes.MapPageRoute("", "tggt-400", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "tggt-400" } });
        routes.MapPageRoute("", "en/tggt-400", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "tggt-400" } });
        routes.MapPageRoute("", "tggt-400.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "tggt-400" } });
        routes.MapPageRoute("", "en/tggt-400.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "tggt-400" } });
        routes.MapPageRoute("", "tggt-5256", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "tggt-5256" } });
        routes.MapPageRoute("", "en/tggt-5256", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "tggt-5256" } });
        routes.MapPageRoute("", "tggt-5256.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "tggt-5256" } });
        routes.MapPageRoute("", "en/tggt-5256.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "tggt-5256" } });
        //silicone-wire
        routes.MapPageRoute("", "pse3323", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "pse3323" } });
        routes.MapPageRoute("", "en/pse3323", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "pse3323" } });
        routes.MapPageRoute("", "pse3323.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "pse3323" } });
        routes.MapPageRoute("", "en/pse3323.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "pse3323" } });
        routes.MapPageRoute("", "ul3123", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3123" } });
        routes.MapPageRoute("", "en/ul3123", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3123" } });
        routes.MapPageRoute("", "ul3123.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3123" } });
        routes.MapPageRoute("", "en/ul3123.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3123" } });
        routes.MapPageRoute("", "ul3132", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3132" } });
        routes.MapPageRoute("", "en/ul3132", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3132" } });
        routes.MapPageRoute("", "ul3132.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3132" } });
        routes.MapPageRoute("", "en/ul3132.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3132" } });
        routes.MapPageRoute("", "ul3133", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3133" } });
        routes.MapPageRoute("", "en/ul3133", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3133" } });
        routes.MapPageRoute("", "ul3133.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3133" } });
        routes.MapPageRoute("", "en/ul3133.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3133" } });
        routes.MapPageRoute("", "ul3134", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3134" } });
        routes.MapPageRoute("", "en/ul3134", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3134" } });
        routes.MapPageRoute("", "ul3134.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3134" } });
        routes.MapPageRoute("", "en/ul3134.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3134" } });
        routes.MapPageRoute("", "ul3135", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3135" } });
        routes.MapPageRoute("", "en/ul3135", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3135" } });
        routes.MapPageRoute("", "ul3135.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3135" } });
        routes.MapPageRoute("", "en/ul3135.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3135" } });
        routes.MapPageRoute("", "ul3136", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3136" } });
        routes.MapPageRoute("", "en/ul3136", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3136" } });
        routes.MapPageRoute("", "ul3136.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3136" } });
        routes.MapPageRoute("", "en/ul3136.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3136" } });
        routes.MapPageRoute("", "ul3138", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3138" } });
        routes.MapPageRoute("", "en/ul3138", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3138" } });
        routes.MapPageRoute("", "ul3138.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3138" } });
        routes.MapPageRoute("", "en/ul3138.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3138" } });
        routes.MapPageRoute("", "ul3139", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3139" } });
        routes.MapPageRoute("", "en/ul3139", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3139" } });
        routes.MapPageRoute("", "ul3139.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3139" } });
        routes.MapPageRoute("", "en/ul3139.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3139" } });
        routes.MapPageRoute("", "ul3213", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3213" } });
        routes.MapPageRoute("", "en/ul3213", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3213" } });
        routes.MapPageRoute("", "ul3213.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3213" } });
        routes.MapPageRoute("", "en/ul3213.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3213" } });
        routes.MapPageRoute("", "ul3239", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3239" } });
        routes.MapPageRoute("", "en/ul3239", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3239" } });
        routes.MapPageRoute("", "ul3239.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3239" } });
        routes.MapPageRoute("", "en/ul3239.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3239" } });
        routes.MapPageRoute("", "ul3529", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3529" } });
        routes.MapPageRoute("", "en/ul3529", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3529" } });
        routes.MapPageRoute("", "ul3529.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3529" } });
        routes.MapPageRoute("", "en/ul3529.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3529" } });
        routes.MapPageRoute("", "ul3530", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3530" } });
        routes.MapPageRoute("", "en/ul3530", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3530" } });
        routes.MapPageRoute("", "ul3530.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3530" } });
        routes.MapPageRoute("", "en/ul3530.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3530" } });
        routes.MapPageRoute("", "ul3572", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3572" } });
        routes.MapPageRoute("", "en/ul3572", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3572" } });
        routes.MapPageRoute("", "ul3572.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3572" } });
        routes.MapPageRoute("", "en/ul3572.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3572" } });
        routes.MapPageRoute("", "ul3580", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3580" } });
        routes.MapPageRoute("", "en/ul3580", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3580" } });
        routes.MapPageRoute("", "ul3580.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3580" } });
        routes.MapPageRoute("", "en/ul3580.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3580" } });
        routes.MapPageRoute("", "ul3641", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3641" } });
        routes.MapPageRoute("", "en/ul3641", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3641" } });
        routes.MapPageRoute("", "ul3641.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3641" } });
        routes.MapPageRoute("", "en/ul3641.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3641" } });
        routes.MapPageRoute("", "ul3642", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3642" } });
        routes.MapPageRoute("", "en/ul3642", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3642" } });
        routes.MapPageRoute("", "ul3642.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3642" } });
        routes.MapPageRoute("", "en/ul3642.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3642" } });
        routes.MapPageRoute("", "ul3643", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3643" } });
        routes.MapPageRoute("", "en/ul3643", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3643" } });
        routes.MapPageRoute("", "ul3643.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3643" } });
        routes.MapPageRoute("", "en/ul3643.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3643" } });
        routes.MapPageRoute("", "ul3644", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3644" } });
        routes.MapPageRoute("", "en/ul3644", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3644" } });
        routes.MapPageRoute("", "ul3644.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3644" } });
        routes.MapPageRoute("", "en/ul3644.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3644" } });
        routes.MapPageRoute("", "ul3662", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3662" } });
        routes.MapPageRoute("", "en/ul3662", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3662" } });
        routes.MapPageRoute("", "ul3662.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3662" } });
        routes.MapPageRoute("", "en/ul3662.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3662" } });
        routes.MapPageRoute("", "ul3663", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3663" } });
        routes.MapPageRoute("", "en/ul3663", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3663" } });
        routes.MapPageRoute("", "ul3663.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3663" } });
        routes.MapPageRoute("", "en/ul3663.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3663" } });
        routes.MapPageRoute("", "ul3664", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3664" } });
        routes.MapPageRoute("", "en/ul3664", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3664" } });
        routes.MapPageRoute("", "ul3664.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3664" } });
        routes.MapPageRoute("", "en/ul3664.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3664" } });
        routes.MapPageRoute("", "ul3754", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3754" } });
        routes.MapPageRoute("", "en/ul3754", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3754" } });
        routes.MapPageRoute("", "ul3754.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3754" } });
        routes.MapPageRoute("", "en/ul3754.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3754" } });
        routes.MapPageRoute("", "ul3755", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3755" } });
        routes.MapPageRoute("", "en/ul3755", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3755" } });
        routes.MapPageRoute("", "ul3755.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3755" } });
        routes.MapPageRoute("", "en/ul3755.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3755" } });
        routes.MapPageRoute("", "ul3976", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3976" } });
        routes.MapPageRoute("", "en/ul3976", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3976" } });
        routes.MapPageRoute("", "ul3976.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3976" } });
        routes.MapPageRoute("", "en/ul3976.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3976" } });
        routes.MapPageRoute("", "ul4330", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul4330" } });
        routes.MapPageRoute("", "en/ul4330", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul4330" } });
        routes.MapPageRoute("", "ul4330.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul4330" } });
        routes.MapPageRoute("", "en/ul4330.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul4330" } });
        routes.MapPageRoute("", "ul4476", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul4476" } });
        routes.MapPageRoute("", "en/ul4476", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul4476" } });
        routes.MapPageRoute("", "ul4476.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul4476" } });
        routes.MapPageRoute("", "en/ul4476.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul4476" } });
        routes.MapPageRoute("", "vde-fg4g4", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "vde-fg4g4" } });
        routes.MapPageRoute("", "en/vde-fg4g4", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "vde-fg4g4" } });
        routes.MapPageRoute("", "vde-fg4g4.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "vde-fg4g4" } });
        routes.MapPageRoute("", "en/vde-fg4g4.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "vde-fg4g4" } });
        routes.MapPageRoute("", "vde-h05s-k", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "vde-h05s-k" } });
        routes.MapPageRoute("", "en/vde-h05s-k", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "vde-h05s-k" } });
        routes.MapPageRoute("", "vde-h05s-k.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "vde-h05s-k" } });
        routes.MapPageRoute("", "en/vde-h05s-k.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "vde-h05s-k" } });
        routes.MapPageRoute("", "vde-h05ss-f", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "vde-h05ss-f" } });
        routes.MapPageRoute("", "en/vde-h05ss-f", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "vde-h05ss-f" } });
        routes.MapPageRoute("", "vde-h05ss-f.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "vde-h05ss-f" } });
        routes.MapPageRoute("", "en/vde-h05ss-f.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "vde-h05ss-f" } });
        routes.MapPageRoute("", "vde-reg-nr-103874", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "vde-reg-nr-103874" } });
        routes.MapPageRoute("", "en/vde-reg-nr-103874", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "vde-reg-nr-103874" } });
        routes.MapPageRoute("", "vde-reg-nr-103874.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "vde-reg-nr-103874" } });
        routes.MapPageRoute("", "en/vde-reg-nr-103874.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "vde-reg-nr-103874" } });
        //teflon-wire
        routes.MapPageRoute("", "ul10109", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul10109" } });
        routes.MapPageRoute("", "en/ul10109", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul10109" } });
        routes.MapPageRoute("", "ul10109.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul10109" } });
        routes.MapPageRoute("", "en/ul10109.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul10109" } });
        routes.MapPageRoute("", "ul10344", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul10344" } });
        routes.MapPageRoute("", "en/ul10344", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul10344" } });
        routes.MapPageRoute("", "ul10344.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul10344" } });
        routes.MapPageRoute("", "en/ul10344.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul10344" } });
        routes.MapPageRoute("", "ul10362", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul10362" } });
        routes.MapPageRoute("", "en/ul10362", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul10362" } });
        routes.MapPageRoute("", "ul10362.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul10362" } });
        routes.MapPageRoute("", "en/ul10362.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul10362" } });
        routes.MapPageRoute("", "ul10393", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul10393" } });
        routes.MapPageRoute("", "en/ul10393", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul10393" } });
        routes.MapPageRoute("", "ul10393.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul10393" } });
        routes.MapPageRoute("", "en/ul10393.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul10393" } });
        routes.MapPageRoute("", "ul11331", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul11331" } });
        routes.MapPageRoute("", "en/ul11331", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul11331" } });
        routes.MapPageRoute("", "ul11331.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul11331" } });
        routes.MapPageRoute("", "en/ul11331.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul11331" } });
        routes.MapPageRoute("", "ul11817", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul11817" } });
        routes.MapPageRoute("", "en/ul11817", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul11817" } });
        routes.MapPageRoute("", "ul11817.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul11817" } });
        routes.MapPageRoute("", "en/ul11817.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul11817" } });
        routes.MapPageRoute("", "ul1199", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1199" } });
        routes.MapPageRoute("", "en/ul1199", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1199" } });
        routes.MapPageRoute("", "ul1199.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1199" } });
        routes.MapPageRoute("", "en/ul1199.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1199" } });
        routes.MapPageRoute("", "ul1330", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1330" } });
        routes.MapPageRoute("", "en/ul1330", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1330" } });
        routes.MapPageRoute("", "ul1330.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1330" } });
        routes.MapPageRoute("", "en/ul1330.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1330" } });
        routes.MapPageRoute("", "ul1331", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1331" } });
        routes.MapPageRoute("", "en/ul1331", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1331" } });
        routes.MapPageRoute("", "ul1331.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1331" } });
        routes.MapPageRoute("", "en/ul1331.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1331" } });
        routes.MapPageRoute("", "ul1332", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1332" } });
        routes.MapPageRoute("", "en/ul1332", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1332" } });
        routes.MapPageRoute("", "ul1332.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1332" } });
        routes.MapPageRoute("", "en/ul1332.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1332" } });
        routes.MapPageRoute("", "ul1709", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1709" } });
        routes.MapPageRoute("", "en/ul1709", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1709" } });
        routes.MapPageRoute("", "ul1709.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1709" } });
        routes.MapPageRoute("", "en/ul1709.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1709" } });
        routes.MapPageRoute("", "ul1710", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1710" } });
        routes.MapPageRoute("", "en/ul1710", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1710" } });
        routes.MapPageRoute("", "ul1710.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1710" } });
        routes.MapPageRoute("", "en/ul1710.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1710" } });
        routes.MapPageRoute("", "ul1726", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1726" } });
        routes.MapPageRoute("", "en/ul1726", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1726" } });
        routes.MapPageRoute("", "ul1726.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1726" } });
        routes.MapPageRoute("", "en/ul1726.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1726" } });
        routes.MapPageRoute("", "ul1727", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1727" } });
        routes.MapPageRoute("", "en/ul1727", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1727" } });
        routes.MapPageRoute("", "ul1727.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1727" } });
        routes.MapPageRoute("", "en/ul1727.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1727" } });
        routes.MapPageRoute("", "ul1813", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1813" } });
        routes.MapPageRoute("", "en/ul1813", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1813" } });
        routes.MapPageRoute("", "ul1813.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1813" } });
        routes.MapPageRoute("", "en/ul1813.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1813" } });
        routes.MapPageRoute("", "ul1887", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1887" } });
        routes.MapPageRoute("", "en/ul1887", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1887" } });
        routes.MapPageRoute("", "ul1887.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1887" } });
        routes.MapPageRoute("", "en/ul1887.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1887" } });
        routes.MapPageRoute("", "ul1901", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1901" } });
        routes.MapPageRoute("", "en/ul1901", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1901" } });
        routes.MapPageRoute("", "ul1901.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1901" } });
        routes.MapPageRoute("", "en/ul1901.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1901" } });
        routes.MapPageRoute("", "ul2748", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul2748" } });
        routes.MapPageRoute("", "en/ul2748", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul2748" } });
        routes.MapPageRoute("", "ul2748.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul2748" } });
        routes.MapPageRoute("", "en/ul2748.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul2748" } });
        routes.MapPageRoute("", "ul2750", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul2750" } });
        routes.MapPageRoute("", "en/ul2750", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul2750" } });
        routes.MapPageRoute("", "ul2750.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul2750" } });
        routes.MapPageRoute("", "en/ul2750.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul2750" } });
        routes.MapPageRoute("", "ul2894", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul2894" } });
        routes.MapPageRoute("", "en/ul2894", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul2894" } });
        routes.MapPageRoute("", "ul2894.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul2894" } });
        routes.MapPageRoute("", "en/ul2894.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul2894" } });
        routes.MapPageRoute("", "ul2895", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul2895" } });
        routes.MapPageRoute("", "en/ul2895", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul2895" } });
        routes.MapPageRoute("", "ul2895.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul2895" } });
        routes.MapPageRoute("", "en/ul2895.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul2895" } });
        routes.MapPageRoute("", "vde-8219", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "vde-8219" } });
        routes.MapPageRoute("", "en/vde-8219", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "vde-8219" } });
        routes.MapPageRoute("", "vde-8219.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "vde-8219" } });
        routes.MapPageRoute("", "en/vde-8219.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "vde-8219" } });
        routes.MapPageRoute("", "vde-8220", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "vde-8220" } });
        routes.MapPageRoute("", "en/vde-8220", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "vde-8220" } });
        routes.MapPageRoute("", "vde-8220.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "vde-8220" } });
        routes.MapPageRoute("", "en/vde-8220.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "vde-8220" } });
        routes.MapPageRoute("", "vde-reg-nr-8295", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "vde-reg-nr-8295" } });
        routes.MapPageRoute("", "en/vde-reg-nr-8295", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "vde-reg-nr-8295" } });
        routes.MapPageRoute("", "vde-reg-nr-8295.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "vde-reg-nr-8295" } });
        routes.MapPageRoute("", "en/vde-reg-nr-8295.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "vde-reg-nr-8295" } });
        //xlpe-wire
        routes.MapPageRoute("", "ul10368", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul10368" } });
        routes.MapPageRoute("", "en/ul10368", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul10368" } });
        routes.MapPageRoute("", "ul10368.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul10368" } });
        routes.MapPageRoute("", "en/ul10368.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul10368" } });
        routes.MapPageRoute("", "ul1430", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1430" } });
        routes.MapPageRoute("", "en/ul1430", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1430" } });
        routes.MapPageRoute("", "ul1430.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1430" } });
        routes.MapPageRoute("", "en/ul1430.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1430" } });
        routes.MapPageRoute("", "ul3173", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3173" } });
        routes.MapPageRoute("", "en/ul3173", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3173" } });
        routes.MapPageRoute("", "ul3173.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3173" } });
        routes.MapPageRoute("", "en/ul3173.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3173" } });
        routes.MapPageRoute("", "ul3265", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3265" } });
        routes.MapPageRoute("", "en/ul3265", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3265" } });
        routes.MapPageRoute("", "ul3265.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3265" } });
        routes.MapPageRoute("", "en/ul3265.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3265" } });
        routes.MapPageRoute("", "ul3266", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3266" } });
        routes.MapPageRoute("", "en/ul3266", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3266" } });
        routes.MapPageRoute("", "ul3266.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3266" } });
        routes.MapPageRoute("", "en/ul3266.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3266" } });
        routes.MapPageRoute("", "ul3271", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3271" } });
        routes.MapPageRoute("", "en/ul3271", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3271" } });
        routes.MapPageRoute("", "ul3271.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3271" } });
        routes.MapPageRoute("", "en/ul3271.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3271" } });
        routes.MapPageRoute("", "ul3272", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3272" } });
        routes.MapPageRoute("", "en/ul3272", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3272" } });
        routes.MapPageRoute("", "ul3272.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3272" } });
        routes.MapPageRoute("", "en/ul3272.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3272" } });
        routes.MapPageRoute("", "ul3290", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3290" } });
        routes.MapPageRoute("", "en/ul3290", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3290" } });
        routes.MapPageRoute("", "ul3290.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3290" } });
        routes.MapPageRoute("", "en/ul3290.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3290" } });
        routes.MapPageRoute("", "ul3302", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3302" } });
        routes.MapPageRoute("", "en/ul3302", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3302" } });
        routes.MapPageRoute("", "ul3302.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3302" } });
        routes.MapPageRoute("", "en/ul3302.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3302" } });
        routes.MapPageRoute("", "ul3320", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3320" } });
        routes.MapPageRoute("", "en/ul3320", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3320" } });
        routes.MapPageRoute("", "ul3320.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3320" } });
        routes.MapPageRoute("", "en/ul3320.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3320" } });
        routes.MapPageRoute("", "ul3321", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3321" } });
        routes.MapPageRoute("", "en/ul3321", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3321" } });
        routes.MapPageRoute("", "ul3321.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3321" } });
        routes.MapPageRoute("", "en/ul3321.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3321" } });
        routes.MapPageRoute("", "ul3385", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3385" } });
        routes.MapPageRoute("", "en/ul3385", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3385" } });
        routes.MapPageRoute("", "ul3385.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3385" } });
        routes.MapPageRoute("", "en/ul3385.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3385" } });
        routes.MapPageRoute("", "ul3386", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3386" } });
        routes.MapPageRoute("", "en/ul3386", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3386" } });
        routes.MapPageRoute("", "ul3386.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3386" } });
        routes.MapPageRoute("", "en/ul3386.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3386" } });
        routes.MapPageRoute("", "ul3613", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3613" } });
        routes.MapPageRoute("", "en/ul3613", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3613" } });
        routes.MapPageRoute("", "ul3613.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3613" } });
        routes.MapPageRoute("", "en/ul3613.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3613" } });
        routes.MapPageRoute("", "ul3688", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3688" } });
        routes.MapPageRoute("", "en/ul3688", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3688" } });
        routes.MapPageRoute("", "ul3688.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3688" } });
        routes.MapPageRoute("", "en/ul3688.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3688" } });
        //pvc-wire
        routes.MapPageRoute("", "ul1007", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1007" } });
        routes.MapPageRoute("", "en/ul1007", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1007" } });
        routes.MapPageRoute("", "ul1007", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1007" } });
        routes.MapPageRoute("", "en/ul1007", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1007" } });
        routes.MapPageRoute("", "ul1015", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1015" } });
        routes.MapPageRoute("", "en/ul1015", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1015" } });
        routes.MapPageRoute("", "ul1015.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul1015" } });
        routes.MapPageRoute("", "en/ul1015.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul1015" } });
        routes.MapPageRoute("", "ul2464", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul2464" } });
        routes.MapPageRoute("", "en/ul2464", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul2464" } });
        routes.MapPageRoute("", "ul2464.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul2464" } });
        routes.MapPageRoute("", "en/ul2464.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul2464" } });
        routes.MapPageRoute("", "ul2517", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul2517" } });
        routes.MapPageRoute("", "en/ul2517", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul2517" } });
        routes.MapPageRoute("", "ul2517.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul2517" } });
        routes.MapPageRoute("", "en/ul2517.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul2517" } });
        //tube
        routes.MapPageRoute("", "ulfrs", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ulfrs" } });
        routes.MapPageRoute("", "en/ulfrs", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ulfrs" } });
        routes.MapPageRoute("", "ulfrs.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ulfrs" } });
        routes.MapPageRoute("", "en/ulfrs.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ulfrs" } });
        routes.MapPageRoute("", "ulhst", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ulhst" } });
        routes.MapPageRoute("", "en/ulhst", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ulhst" } });
        routes.MapPageRoute("", "ulhst.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ulhst" } });
        routes.MapPageRoute("", "en/ulhst.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ulhst" } });
        routes.MapPageRoute("", "ulsrg", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ulssg" } });
        routes.MapPageRoute("", "en/ulsrg", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ulssg" } });
        routes.MapPageRoute("", "ulsrg.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ulssg" } });
        routes.MapPageRoute("", "en/ulsrg.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ulssg" } });
        routes.MapPageRoute("", "pfa-fep-tube", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "fep-tube" } });
        routes.MapPageRoute("", "en/pfa-fep-tube", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "fep-tube" } });
        routes.MapPageRoute("", "pfa-fep-tube.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "fep-tube" } });
        routes.MapPageRoute("", "en/pfa-fep-tube.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "fep-tube" } });
        routes.MapPageRoute("", "ptfe-tube", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ptfe-tube" } });
        routes.MapPageRoute("", "en/ptfe-tube", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ptfe-tube" } });
        routes.MapPageRoute("", "ptfe-tube.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ptfe-tube" } });
        routes.MapPageRoute("", "en/ptfe-tube.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ptfe-tube" } });
        routes.MapPageRoute("", "silicone-tube", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "silicone-tube" } });
        routes.MapPageRoute("", "en/silicone-tube", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "silicone-tube" } });
        routes.MapPageRoute("", "silicone-tube.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "silicone-tube" } });
        routes.MapPageRoute("", "en/silicone-tube.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "silicone-tube" } });
        //thermocouple
        routes.MapPageRoute("", "e-type", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "e-type" } });
        routes.MapPageRoute("", "en/e-type", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "e-type" } });
        routes.MapPageRoute("", "e-type.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "e-type" } });
        routes.MapPageRoute("", "en/e-type.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "e-type" } });
        routes.MapPageRoute("", "j-type", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "j-type" } });
        routes.MapPageRoute("", "en/j-type", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "j-type" } });
        routes.MapPageRoute("", "j-type.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "j-type" } });
        routes.MapPageRoute("", "en/j-type.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "j-type" } });
        routes.MapPageRoute("", "k-type", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "k-type" } });
        routes.MapPageRoute("", "en/k-type", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "k-type" } });
        routes.MapPageRoute("", "k-type.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "k-type" } });
        routes.MapPageRoute("", "en/k-type.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "k-type" } });
        routes.MapPageRoute("", "t-type", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "t-type" } });
        routes.MapPageRoute("", "en/t-type", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "t-type" } });
        routes.MapPageRoute("", "t-type.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "t-type" } });
        routes.MapPageRoute("", "en/t-type.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "t-type" } });
        routes.MapPageRoute("", "rtd", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "rtd" } });
        routes.MapPageRoute("", "en/rtd", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "rtd" } });
        routes.MapPageRoute("", "rtd.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "rtd" } });
        routes.MapPageRoute("", "en/rtd.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "rtd" } });
        routes.MapPageRoute("", "rs-type", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "r-s-type" } });
        routes.MapPageRoute("", "en/rs-type", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "r-s-type" } });
        routes.MapPageRoute("", "rs-type.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "r-s-type" } });
        routes.MapPageRoute("", "en/rs-type.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "r-s-type" } });
        //heating-wire
        routes.MapPageRoute("", "respiration-pipe-heating-wire", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "medical-respiration-pipe-heating-wire" } });
        routes.MapPageRoute("", "en/respiration-pipe-heating-wire", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "medical-respiration-pipe-heating-wire" } });
        routes.MapPageRoute("", "respiration-pipe-heating-wire.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "medical-respiration-pipe-heating-wire" } });
        routes.MapPageRoute("", "en/respiration-pipe-heating-wire.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "medical-respiration-pipe-heating-wire" } });
        routes.MapPageRoute("", "phc", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "phc" } });
        routes.MapPageRoute("", "en/phc", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "phc" } });
        routes.MapPageRoute("", "phc.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "phc" } });
        routes.MapPageRoute("", "en/phc.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "phc" } });
        routes.MapPageRoute("", "ul3323", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3323" } });
        routes.MapPageRoute("", "en/ul3323", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3323" } });
        routes.MapPageRoute("", "ul3323.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3323" } });
        routes.MapPageRoute("", "en/ul3323.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3323" } });
        routes.MapPageRoute("", "ul3350", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3350" } });
        routes.MapPageRoute("", "en/ul3350", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3350" } });
        routes.MapPageRoute("", "ul3350.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3350" } });
        routes.MapPageRoute("", "en/ul3350.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3350" } });
        routes.MapPageRoute("", "ul3589", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3589" } });
        routes.MapPageRoute("", "en/ul3589", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3589" } });
        routes.MapPageRoute("", "ul3589.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3589" } });
        routes.MapPageRoute("", "en/ul3589.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3589" } });
        routes.MapPageRoute("", "ul3590", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3590" } });
        routes.MapPageRoute("", "en/ul3590", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3590" } });
        routes.MapPageRoute("", "ul3590.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3590" } });
        routes.MapPageRoute("", "en/ul3590.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3590" } });
        //automobile-wire
        //composite-wire
        routes.MapPageRoute("", "rg178bu-rg179-rg316", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "rg179" } });
        routes.MapPageRoute("", "en/rg178bu-rg179-rg316", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "rg179" } });
        routes.MapPageRoute("", "rg178bu-rg179-rg316.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "rg179" } });
        routes.MapPageRoute("", "en/rg178bu-rg179-rg316.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "rg179" } });
        routes.MapPageRoute("", "teflon-silicone-medical-wire", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "teflon-silicone-medical-wire" } });
        routes.MapPageRoute("", "en/teflon-silicone-medical-wire", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "teflon-silicone-medical-wire" } });
        routes.MapPageRoute("", "teflon-silicone-medical-wire.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "teflon-silicone-medical-wire" } });
        routes.MapPageRoute("", "en/teflon-silicone-medical-wire.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "teflon-silicone-medical-wire" } });
        routes.MapPageRoute("", "ul3270", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3270" } });
        routes.MapPageRoute("", "en/ul3270", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3270" } });
        routes.MapPageRoute("", "ul3270.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul3270" } });
        routes.MapPageRoute("", "en/ul3270.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul3270" } });
        //anti-refrigerant-wire
        routes.MapPageRoute("", "ul5048", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul5048" } });
        routes.MapPageRoute("", "en/ul5048", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul5048" } });
        routes.MapPageRoute("", "ul5048.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "ul5048" } });
        routes.MapPageRoute("", "en/ul5048.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "ul5048" } });
        //automobile-wire
        routes.MapPageRoute("", "fl2x-a", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-fl2x-a" } });
        routes.MapPageRoute("", "en/fl2x-a", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-fl2x-a" } });
        routes.MapPageRoute("", "fl2x-a.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-fl2x-a" } });
        routes.MapPageRoute("", "en/fl2x-a.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-fl2x-a" } });
        routes.MapPageRoute("", "fl2x-b", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-fl2x-b" } });
        routes.MapPageRoute("", "en/fl2x-b", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-fl2x-b" } });
        routes.MapPageRoute("", "fl2x-b.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-fl2x-b" } });
        routes.MapPageRoute("", "en/fl2x-b.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-fl2x-b" } });
        routes.MapPageRoute("", "flr2x-a", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flr2x-a" } });
        routes.MapPageRoute("", "en/flr2x-a", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flr2x-a" } });
        routes.MapPageRoute("", "flr2x-a.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flr2x-a" } });
        routes.MapPageRoute("", "en/flr2x-a.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flr2x-a" } });
        routes.MapPageRoute("", "flr2x-b", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flr2x-b" } });
        routes.MapPageRoute("", "en/flr2x-b", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flr2x-b" } });
        routes.MapPageRoute("", "flr2x-b.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flr2x-b" } });
        routes.MapPageRoute("", "en/flr2x-b.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flr2x-b" } });
        routes.MapPageRoute("", "flr13ya", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flr13y-a" } });
        routes.MapPageRoute("", "en/flr13ya", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flr13y-a" } });
        routes.MapPageRoute("", "flr13ya.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flr13y-a" } });
        routes.MapPageRoute("", "en/flr13ya.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flr13y-a" } });
        routes.MapPageRoute("", "flry-a", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flry-a" } });
        routes.MapPageRoute("", "en/flry-a", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flry-a" } });
        routes.MapPageRoute("", "flry-a.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flry-a" } });
        routes.MapPageRoute("", "en/flry-a.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flry-a" } });
        routes.MapPageRoute("", "flry-b", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flry-b" } });
        routes.MapPageRoute("", "en/flry-b", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flry-b" } });
        routes.MapPageRoute("", "flry-b.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flry-b" } });
        routes.MapPageRoute("", "en/flry-b.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flry-b" } });
        routes.MapPageRoute("", "flrynx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flrynx" } });
        routes.MapPageRoute("", "en/flrynx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flrynx" } });
        routes.MapPageRoute("", "flrynx.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flrynx" } });
        routes.MapPageRoute("", "en/flrynx.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flrynx" } });
        routes.MapPageRoute("", "flryw-a", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flryw-a" } });
        routes.MapPageRoute("", "en/flryw-a", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flryw-a" } });
        routes.MapPageRoute("", "flryw-a.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flryw-a" } });
        routes.MapPageRoute("", "en/flryw-a.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flryw-a" } });
        routes.MapPageRoute("", "flryw-b", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flryw-b" } });
        routes.MapPageRoute("", "en/flryw-b", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flryw-b" } });
        routes.MapPageRoute("", "flryw-b.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flryw-b" } });
        routes.MapPageRoute("", "en/flryw-b.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flryw-b" } });
        routes.MapPageRoute("", "flryy", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flryy" } });
        routes.MapPageRoute("", "en/flryy", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flryy" } });
        routes.MapPageRoute("", "flryy.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flryy" } });
        routes.MapPageRoute("", "en/flryy.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flryy" } });
        routes.MapPageRoute("", "fly", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-fly" } });
        routes.MapPageRoute("", "en/fly", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-fly" } });
        routes.MapPageRoute("", "fly.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-fly" } });
        routes.MapPageRoute("", "en/fly.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-fly" } });
        routes.MapPageRoute("", "flyw", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flyw" } });
        routes.MapPageRoute("", "en/flyw", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flyw" } });
        routes.MapPageRoute("", "flyw.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flyw" } });
        routes.MapPageRoute("", "en/flyw.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flyw" } });
        routes.MapPageRoute("", "flyy-multi", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flyy-multi" } });
        routes.MapPageRoute("", "en/flyy-multi", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flyy-multi" } });
        routes.MapPageRoute("", "flyy-multi.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flyy-multi" } });
        routes.MapPageRoute("", "en/flyy-multi.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flyy-multi" } });
        routes.MapPageRoute("", "flyy-single", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flyy-single" } });
        routes.MapPageRoute("", "en/flyy-single", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flyy-single" } });
        routes.MapPageRoute("", "flyy-single.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "iso-flyy-single" } });
        routes.MapPageRoute("", "en/flyy-single.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "iso-flyy-single" } });
        routes.MapPageRoute("", "aessx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-aessx" } });
        routes.MapPageRoute("", "en/aessx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-aessx" } });
        routes.MapPageRoute("", "aessx.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-aessx" } });
        routes.MapPageRoute("", "en/aessx.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-aessx" } });
        routes.MapPageRoute("", "aex", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-aex" } });
        routes.MapPageRoute("", "en/aex", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-aex" } });
        routes.MapPageRoute("", "aex.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-aex" } });
        routes.MapPageRoute("", "en/aex.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-aex" } });
        routes.MapPageRoute("", "asssh-shsx-shsh", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-asssh" } });
        routes.MapPageRoute("", "en/asssh-shsx-shsh", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-asssh" } });
        routes.MapPageRoute("", "asssh-shsx-shsh.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-asssh" } });
        routes.MapPageRoute("", "en/asssh-shsx-shsh.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-asssh" } });
        routes.MapPageRoute("", "av", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-av" } });
        routes.MapPageRoute("", "en/av", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-av" } });
        routes.MapPageRoute("", "av.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-av" } });
        routes.MapPageRoute("", "en/av.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-av" } });
        routes.MapPageRoute("", "avs", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-avs" } });
        routes.MapPageRoute("", "en/avs", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-avs" } });
        routes.MapPageRoute("", "avs.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-avs" } });
        routes.MapPageRoute("", "en/avs.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-avs" } });
        routes.MapPageRoute("", "avss", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-avss" } });
        routes.MapPageRoute("", "en/avss", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-avss" } });
        routes.MapPageRoute("", "avss.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-avss" } });
        routes.MapPageRoute("", "en/avss.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-avss" } });
        routes.MapPageRoute("", "avssh", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-avssh" } });
        routes.MapPageRoute("", "en/avssh", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-avssh" } });
        routes.MapPageRoute("", "avssh.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-avssh" } });
        routes.MapPageRoute("", "en/avssh.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-avssh" } });
        routes.MapPageRoute("", "avx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-avx" } });
        routes.MapPageRoute("", "en/avx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-avx" } });
        routes.MapPageRoute("", "avx.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-avx" } });
        routes.MapPageRoute("", "en/avx.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-avx" } });
        routes.MapPageRoute("", "cavs", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-cavs" } });
        routes.MapPageRoute("", "en/cavs", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-cavs" } });
        routes.MapPageRoute("", "cavs.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-cavs" } });
        routes.MapPageRoute("", "en/cavs.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-cavs" } });
        routes.MapPageRoute("", "cavus", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-cavus" } });
        routes.MapPageRoute("", "en/cavus", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-cavus" } });
        routes.MapPageRoute("", "cavus.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-cavus" } });
        routes.MapPageRoute("", "en/cavus.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-cavus" } });
        routes.MapPageRoute("", "chfus", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-chfus" } });
        routes.MapPageRoute("", "en/chfus", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-chfus" } });
        routes.MapPageRoute("", "chfus.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-chfus" } });
        routes.MapPageRoute("", "en/chfus.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-chfus" } });
        routes.MapPageRoute("", "civus", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-civus" } });
        routes.MapPageRoute("", "en/civus", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-civus" } });
        routes.MapPageRoute("", "civus.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-civus" } });
        routes.MapPageRoute("", "en/civus.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-civus" } });
        routes.MapPageRoute("", "hfss", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-hfss" } });
        routes.MapPageRoute("", "en/hfss", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-hfss" } });
        routes.MapPageRoute("", "hfss.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-hfss" } });
        routes.MapPageRoute("", "en/hfss.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-hfss" } });
        routes.MapPageRoute("", "ivssh", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-ivssh" } });
        routes.MapPageRoute("", "en/ivssh", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-ivssh" } });
        routes.MapPageRoute("", "ivssh.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-ivssh" } });
        routes.MapPageRoute("", "en/ivssh.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-ivssh" } });
        routes.MapPageRoute("", "less-lesx-lesh", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-le-sh" } });
        routes.MapPageRoute("", "en/less-lesx-lesh", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-le-sh" } });
        routes.MapPageRoute("", "less-lesx-lesh.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "jaso-le-sh" } });
        routes.MapPageRoute("", "en/less-lesx-lesh.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "jaso-le-sh" } });
        routes.MapPageRoute("", "gpt", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "sae-gpt" } });
        routes.MapPageRoute("", "en/gpt", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "sae-gpt" } });
        routes.MapPageRoute("", "gpt.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "sae-gpt" } });
        routes.MapPageRoute("", "en/gpt.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "sae-gpt" } });
        routes.MapPageRoute("", "gxl", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "sae-gxl" } });
        routes.MapPageRoute("", "en/gxl", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "sae-gxl" } });
        routes.MapPageRoute("", "gxl.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "sae-gxl" } });
        routes.MapPageRoute("", "en/gxl.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "sae-gxl" } });
        routes.MapPageRoute("", "hdt", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "sae-hdt" } });
        routes.MapPageRoute("", "en/hdt", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "sae-hdt" } });
        routes.MapPageRoute("", "hdt.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "sae-hdt" } });
        routes.MapPageRoute("", "en/hdt.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "sae-hdt" } });
        routes.MapPageRoute("", "sxl", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "sae-sxl" } });
        routes.MapPageRoute("", "en/sxl", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "sae-sxl" } });
        routes.MapPageRoute("", "sxl.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "sae-sxl" } });
        routes.MapPageRoute("", "en/sxl.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "sae-sxl" } });
        routes.MapPageRoute("", "twp", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "sae-twp" } });
        routes.MapPageRoute("", "en/twp", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "sae-twp" } });
        routes.MapPageRoute("", "twp.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "sae-twp" } });
        routes.MapPageRoute("", "en/twp.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "sae-twp" } });
        routes.MapPageRoute("", "txl", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "sae-txl" } });
        routes.MapPageRoute("", "en/txl", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "sae-txl" } });
        routes.MapPageRoute("", "txl.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "productID", "sae-txl" } });
        routes.MapPageRoute("", "en/txl.aspx", "~/product-profile.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "productID", "sae-txl" } });

        routes.MapPageRoute("", "engine-power-cable", "~/application/automobile/MOTOR-POWER-CABLE.aspx");

        routes.MapPageRoute("", "military-grade-series", "~/military-grade-wire.aspx", false);
        routes.MapPageRoute("", "military-grade-series.aspx", "~/military-grade-wire.aspx", false);
        routes.MapPageRoute("", "en/military-grade-series", "~/military-grade-wire.aspx", false);
        routes.MapPageRoute("", "en/military-grade-series.aspx", "~/military-grade-wire.aspx", false);
        routes.MapPageRoute("", "silicone-fiberglass-series", "~/silicone-fiberglass-wire.aspx", false);
        routes.MapPageRoute("", "silicone-fiberglass-series.aspx", "~/silicone-fiberglass-wire.aspx", false);
        routes.MapPageRoute("", "en/silicone-fiberglass-series", "~/silicone-fiberglass-wire.aspx", false);
        routes.MapPageRoute("", "en/silicone-fiberglass-series.aspx", "~/silicone-fiberglass-wire.aspx", false);
        routes.MapPageRoute("", "high-temperature-resistance-series", "~/high-temperature-wire.aspx", false);
        routes.MapPageRoute("", "high-temperature-resistance-series.aspx", "~/high-temperature-wire.aspx", false);
        routes.MapPageRoute("", "en/high-temperature-resistance-seriess", "~/high-temperature-wire.aspx", false);
        routes.MapPageRoute("", "en/high-temperature-resistance-series.aspx", "~/high-temperature-wire.aspx", false);
        routes.MapPageRoute("", "silicone-series", "~/silicone-wire.aspx", false);
        routes.MapPageRoute("", "silicone-series.aspx", "~/silicone-wire.aspx", false);
        routes.MapPageRoute("", "en/silicone-series", "~/silicone-wire.aspx", false);
        routes.MapPageRoute("", "en/silicone-series.aspx", "~/silicone-wire.aspx", false);
        routes.MapPageRoute("", "teflon-series", "~/teflon-wire.aspx", false);
        routes.MapPageRoute("", "teflon-series.aspx", "~/teflon-wire.aspx", false);
        routes.MapPageRoute("", "en/teflon-series", "~/teflon-wire.aspx", false);
        routes.MapPageRoute("", "en/teflone-series.aspx", "~/teflon-wire.aspx", false);
        routes.MapPageRoute("", "xlpe-series", "~/xlpe-wire.aspx", false);
        routes.MapPageRoute("", "xlpe-series.aspx", "~/xlpe-wire.aspx", false);
        routes.MapPageRoute("", "en/xlpe-series", "~/xlpe-wire.aspx", false);
        routes.MapPageRoute("", "en/xlpe-series.aspx", "~/xlpee-wire.aspx", false);
        routes.MapPageRoute("", "pvc-series", "~/pvc-wire.aspx", false);
        routes.MapPageRoute("", "pvc-series.aspx", "~/pvc-wire.aspx", false);
        routes.MapPageRoute("", "en/pvc-series", "~/pvc-wire.aspx", false);
        routes.MapPageRoute("", "en/pvc-series.aspx", "~/pvc-wire.aspx", false);
        routes.MapPageRoute("", "sleeve-and-tube-series", "~/tube.aspx", false);
        routes.MapPageRoute("", "sleeve-and-tube-series.aspx", "~/tube.aspx", false);
        routes.MapPageRoute("", "en/sleeve-and-tube-series", "~/tube.aspx", false);
        routes.MapPageRoute("", "en/sleeve-and-tube-series.aspx", "~/tube.aspx", false);
        routes.MapPageRoute("", "thermocouple-series", "~/thermocouple.aspx", false);
        routes.MapPageRoute("", "thermocouple-series.aspx", "~/thermocouple.aspx", false);
        routes.MapPageRoute("", "en/thermocouple-series", "~/thermocouple.aspx", false);
        routes.MapPageRoute("", "en/thermocouple-series.aspx", "~/thermocouple.aspx", false);
        routes.MapPageRoute("", "heating-wire-series", "~/heating-wire.aspx", false);
        routes.MapPageRoute("", "heating-wire-series.aspx", "~/heating-wire.aspx", false);
        routes.MapPageRoute("", "en/heating-wire-series", "~/heating-wire.aspx", false);
        routes.MapPageRoute("", "en/heating-wire-series.aspx", "~/heating-wire.aspx", false);
        routes.MapPageRoute("", "automotive-wire-series", "~/automobile-wire.aspx", false);
        routes.MapPageRoute("", "automotive-wire-series.aspx", "~/automobile-wire.aspx", false);
        routes.MapPageRoute("", "en/automotive-wire-series", "~/automobile-wire.aspx", false);
        routes.MapPageRoute("", "en/automotive-wire-series.aspx", "~/automobile-wire.aspx", false);
        routes.MapPageRoute("", "automotive-wire-standard-iso", "~/automobile-wire.aspx", false);
        routes.MapPageRoute("", "automotive-wire-standard-iso.aspx", "~/automobile-wire.aspx", false);
        routes.MapPageRoute("", "en/automotive-wire-standard-iso", "~/automobile-wire.aspx", false);
        routes.MapPageRoute("", "en/automotive-wire-standard-iso.aspx", "~/automobile-wire.aspx", false);
        routes.MapPageRoute("", "automotive-wire-standard-sae", "~/automobile-wire.aspx", false);
        routes.MapPageRoute("", "automotive-wire-standard-sae.aspx", "~/automobile-wire.aspx", false);
        routes.MapPageRoute("", "en/automotive-wire-standard-sae", "~/automobile-wire.aspx", false);
        routes.MapPageRoute("", "en/automotive-wire-standard-sae.aspx", "~/automobile-wire.aspx", false);
        routes.MapPageRoute("", "automotive-wire-standard-jaso", "~/automobile-wire.aspx", false);
        routes.MapPageRoute("", "automotive-wire-standard-jaso.aspx", "~/automobile-wire.aspx", false);
        routes.MapPageRoute("", "en/automotive-wire-standard-jaso", "~/automobile-wire.aspx", false);
        routes.MapPageRoute("", "en/automotive-wire-standard-jaso.aspx", "~/automobile-wire.aspx", false);
        routes.MapPageRoute("", "special-cable", "~/composite-cable.aspx", false);
        routes.MapPageRoute("", "special-cable.aspx", "~/composite-cable.aspx", false);
        routes.MapPageRoute("", "en/special-cable", "~/composite-cable.aspx", false);
        routes.MapPageRoute("", "en/special-cable.aspx", "~/composite-cable.aspx", false);
        
        

        routes.MapPageRoute("", "car", "~/application-list.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "application", "automobile" } });
        routes.MapPageRoute("", "en/car", "~/application-list.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "application", "automobile" } });
        routes.MapPageRoute("", "medical", "~/application-list.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "application", "medical" } });
        routes.MapPageRoute("", "en/medical", "~/application-list.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "application", "medical" } });
        routes.MapPageRoute("", "cloud", "~/application-list.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "zh" }, { "application", "cloud-system" } });
        routes.MapPageRoute("", "en/cloud", "~/application-list.aspx", true,
            new RouteValueDictionary { }, new RouteValueDictionary { },
            new RouteValueDictionary { { "language", "en" }, { "application", "cloud-system" } });


        //redirect deprecated pages to relevant category pages
        routes.MapPageRoute("", "cat6a10gsutp", "~/pvc-wire.aspx");
        routes.MapPageRoute("", "en/cat6a10gsutp", "~/pvc-wire.aspx");
        routes.MapPageRoute("", "cat6a10gsutp.aspx", "~/pvc-wire.aspx");
        routes.MapPageRoute("", "en/cat6a10gsutp.aspx", "~/pvc-wire.aspx");

        routes.MapPageRoute("", "cat6a10gsftp", "~/pvc-wire.aspx");
        routes.MapPageRoute("", "en/cat6a10gsftp", "~/pvc-wire.aspx");
        routes.MapPageRoute("", "cat6a10gsftp.aspx", "~/pvc-wire.aspx");
        routes.MapPageRoute("", "en/cat6a10gsftp.aspx", "~/pvc-wire.aspx");

        routes.MapPageRoute("", "cat710gplussftp", "~/pvc-wire.aspx");
        routes.MapPageRoute("", "en/cat710gplussftp", "~/pvc-wire.aspx");
        routes.MapPageRoute("", "cat710gplussftp.aspx", "~/pvc-wire.aspx");
        routes.MapPageRoute("", "en/cat710gplussftp.aspx", "~/pvc-wire.aspx");

        routes.MapPageRoute("", "mil-c-24643-23-08", "~/military-grade-wire.aspx");
        routes.MapPageRoute("", "en/mil-c-24643-23-08", "~/military-grade-wire.aspx");
        routes.MapPageRoute("", "mil-c-24643-23-08.aspx", "~/military-grade-wire.aspx");
        routes.MapPageRoute("", "en/mil-c-24643-23-08.aspx", "~/military-grade-wire.aspx");
        
        routes.MapPageRoute("", "double-shield-fep-sili-cable", "~/teflon-wire.aspx");
        routes.MapPageRoute("", "en/double-shield-fep-sili-cable", "~/teflon-wire.aspx");
        routes.MapPageRoute("", "double-shield-fep-sili-cable.aspx", "~/teflon-wire.aspx");
        routes.MapPageRoute("", "en/double-shield-fep-sili-cable.aspx", "~/teflon-wire.aspx");

        routes.MapPageRoute("", "defibrillator-signal-wire", "~/pvc-wire.aspx");
        routes.MapPageRoute("", "en/defibrillator-signal-wire", "~/pvc-wire.aspx");
        routes.MapPageRoute("", "defibrillator-signal-wire.aspx", "~/pvc-wire.aspx");
        routes.MapPageRoute("", "en/defibrillator-signal-wire.aspx", "~/pvc-wire.aspx");

        routes.MapPageRoute("", "{language}/silicone-fiberglass-wire", "~/silicone-fiberglass-wire.aspx");

        routes.MapPageRoute("", "ccs", "~/conductor-category.aspx", false);

        routes.MapPageRoute("", "en/conductor", "~/conductor-category.aspx", false);
        routes.MapPageRoute("", "en/nicu", "~/conductor-category.aspx", false);
        routes.MapPageRoute("", "en/copper", "~/conductor-category.aspx", false);
        routes.MapPageRoute("", "en/sncu", "~/conductor-category.aspx", false);
        routes.MapPageRoute("", "en/ccs", "~/conductor-category.aspx", false);

        routes.MapPageRoute("", "en/quality-certificate", "~/certificate.aspx");
        routes.MapPageRoute("", "vde", "~/certificate.aspx");
        routes.MapPageRoute("", "en/vde", "~/certificate.aspx");

        routes.MapPageRoute("", "en/contact_us", "~/contact_us.aspx");

        routes.MapPageRoute("", "navigation", "~/sitemap.aspx");

        var settings = new FriendlyUrlSettings();
        settings.AutoRedirectMode = RedirectMode.Permanent;
        routes.EnableFriendlyUrls(settings);
        routes.RouteExistingFiles = true;
    }

</script>
