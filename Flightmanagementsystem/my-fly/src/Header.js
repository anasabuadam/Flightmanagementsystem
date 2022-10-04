import React from 'react';


function Header() {
    return (
        <div className="Header fixed-top">
            <nav className="navbar navbar-expand-sm bg-dark navbar-dark  text-white  ">
            <a class="navbar-brand " href="#">
                Flight Management System
            </a>
            <button class="navbar-toggler"
                type="button"
                data-toggle="Toggler"
                data-target="#collapsibleNavbar">
                <span
                    class="navbar-toggler-icon">
                </span>
            </button>
            <div class="collapse navbar-collapse"
                id="collapsibleNavbar">
                <ul
                    class="navbar-nav">
                    <li
                        class="nav-item">
                        <a
                            class="nav-link" href="../src/comp/LoginPage.js">Login
                        </a>
                    </li>
                    <li
                        class="nav-item">
                        <a
                            class="nav-link" href="#">About
                        </a>
                    </li>
                    <li
                        class="nav-item">
                        <a
                            class="nav-link" href="#">GetTickt
                        </a>
                    </li>
                    <li
                        class="nav-item">
                        <a
                            class="nav-link" href="#">Search AirLine Company
                        </a>
                    </li>
                </ul>
            </div>
            <div id="root">
            </div>
            </nav>
       </div>



        )
}
export default Header