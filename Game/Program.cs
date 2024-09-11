using Adventure;

var g = new Game();

var room = g.DemoGame();
Player player = new(room);
g.Play(player);
