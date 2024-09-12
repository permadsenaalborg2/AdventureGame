using Adventure;

var g = new Game();

var room = new DemoGame().StartRoom;
Player player = new(room);
g.Play(player);
