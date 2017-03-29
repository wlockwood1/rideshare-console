using System;

public interface ICarType
{

   	void MoveUp(int yPos);
    void MoveDown(int yPos);
    void MoveLeft(int xPos);
    void MoveRight(int xPos);
    void WritePositionToConsole();
}