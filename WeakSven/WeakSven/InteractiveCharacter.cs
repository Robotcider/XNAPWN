namespace WeakSven
{
	class InteractiveCharacter : Character
	{
		public int Health { get; protected set; }
		public int Attack { get; protected set; }
		public int Defense { get; protected set; }
		public int Money { get; protected set; }

		public InteractiveCharacter()
			: base()
		{

		}
	}
}