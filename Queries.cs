using System;

public class Queries
{
	public SQLQueries()
	{
		
		public abstract void QueryDb()
		{
            from c in Characters
            join i in Moves
            on c.charId equals i.charId
            select new
            {
                c.name,
                i.moveName,
                i.moveNotation,
            }
            
        }


	}
}
