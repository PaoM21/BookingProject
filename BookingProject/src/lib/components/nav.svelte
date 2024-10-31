<nav>
  <ul>
    <li><a href="#" on:click={() => navigate('home')}>Home</a></li>
    <li><a href="#" on:click={() => navigate('home')}>About</a></li>
    <li><a href="#" on:click={() => navigate('home')}>Contact</a></li>
  </ul>
</nav>

<style>
  nav ul {
    list-style: none;
    padding: 0;
    display: flex;
    gap: 20px;
  }

  nav a {
    text-decoration: none;
    color: #333;
    font-weight: bold;
  }

  nav a:hover {
    color: #007acc;
  }
</style>