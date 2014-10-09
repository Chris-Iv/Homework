import java.util.Scanner;


public class _2_TriangleArea {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int ax = input.nextInt();
		int ay = input.nextInt();
		int bx = input.nextInt();
		int by = input.nextInt();
		int cx = input.nextInt();
		int cy = input.nextInt();
		int a = (int) Math.sqrt((cx - bx) * (cx - bx) + (cy - by) * (cy - by));
		int b = (int) Math.sqrt((cx - ax) * (cx - ax) + (cy - ay) * (cy - ay));
		int c = (int) Math.sqrt((ax - bx) * (ax - bx) + (ay - by) * (ay - by));
		if (a + b > c && a + c > b && b + c > a) {
			int area = (ax * (by - cy) + bx * (cy - ay) + cx * (ay - by)) / 2;
			System.out.println(area);
		} else {
			System.out.println(0);
		}
	}

}
