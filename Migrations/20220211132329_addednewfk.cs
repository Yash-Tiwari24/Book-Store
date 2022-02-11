using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Store.Migrations
{
    public partial class addednewfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGallery_books_BooksId",
                table: "BookGallery");

            migrationBuilder.RenameColumn(
                name: "BooksId",
                table: "BookGallery",
                newName: "booksId");

            migrationBuilder.RenameIndex(
                name: "IX_BookGallery_BooksId",
                table: "BookGallery",
                newName: "IX_BookGallery_booksId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGallery_books_booksId",
                table: "BookGallery",
                column: "booksId",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGallery_books_booksId",
                table: "BookGallery");

            migrationBuilder.RenameColumn(
                name: "booksId",
                table: "BookGallery",
                newName: "BooksId");

            migrationBuilder.RenameIndex(
                name: "IX_BookGallery_booksId",
                table: "BookGallery",
                newName: "IX_BookGallery_BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGallery_books_BooksId",
                table: "BookGallery",
                column: "BooksId",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
