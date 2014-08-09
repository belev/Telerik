namespace _01.FriendsOfPesho
{
    public struct Node
    {
        public Node(int id, int distance)
            : this()
        {
            this.Id = id;
            this.Distance = distance;
        }
    
        public int Id { get; set; }
    
        public int Distance { get; set; }
    }
}
