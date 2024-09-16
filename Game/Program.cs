using Adventure;

var g = new Game();
DemoGame.TechGame(g);

Player player = new("Spiller", g.StartRoom);
g.Play(player);
