import java.awt.Color;
import java.awt.Graphics;

/**
* One element of the snake.
*/
public class Point {
		private int x, y;
		private final int WIDTH = 20;
		private final int HEIGHT = 20;
		
		/**
		* Clones element of the snake.
		* @param p Element of the snake.
		*/
		public Point(Point p){
				this(p.x, p.y);
		}
		
		/**
		* Creates new element of the snake on position X and Y.
		* @param x X coordinate
		* @param y Y coordinate
		*/
		public Point(int x, int y){
				this.x = x;
				this.y = y;
		}
		
		public int getX() {
				return x;
		}
		
		public void setX(int x) {
				this.x = x;
		}
		
		public int getY() {
				return y;
		}
		
		public void setY(int y) {
				this.y = y;
		}
		
		/**
		* Draws snake's element.
		* @param g Object of class Graphics.
		*/
		public void draw(Graphics g, Color color) {
				g.setColor(Color.BLACK);
				g.fillRect(x, y, WIDTH, HEIGHT);
				g.setColor(color);
				g.fillRect(x+1, y+1, WIDTH-2, HEIGHT-2);	
		}
		
		public String toString() {
				return "[x=" + x + ",y=" + y + "]";
		}
		
		public boolean equals(Object objectj) {
				if (objectj instanceof Point) {
						Point point = (Point)objectj;
						return (x == point.x) && (y == point.y);
				}
				
				return false;
		}
}