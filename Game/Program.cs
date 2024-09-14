using Adventure;

var g = new Game();
DemoGame.TechGame(g);

Player player = new(g.StartRoom);
g.Play(player);
