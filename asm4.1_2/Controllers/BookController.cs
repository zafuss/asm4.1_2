using asm4._1_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace asm4._1_2.Controllers
{
    public class BookController : Controller
    {
        static List<Book>? bookList = null;
        static int bookCount = 0;
        static void listInitial()
        {
            bookList = [
       new Book(1, "Violet Bent Backwards Over The Grass", "THE HIGHLY ANTICIPATED DEBUT BOOK OF POETRY FROM LANA DEL REY, VIOLET BENT BACKWARDS OVER THE GRASS\r\n\r\n" +
                "“Violet Bent Backwards Over the Grass is the title poem of the book and the first poem I wrote of many. Some of which came to me in their entirety, which I dictated and then typed out, " +
                "and some that I worked laboriously picking apart each word to make the perfect poem. They are eclectic and honest and not trying to be anything other than what they are and for that reason I’m proud of them, " +
                "especially because the spirit in which they were written was very authentic.” —Lana Del Rey\r\n\r\nLana’s breathtaking first book solidifies her further as “the essential writer of her times” (The Atlantic). " +
                "The collection features more than thirty poems, many exclusive to the book: Never to Heaven, The Land of 1,000 Fires, Past the Bushes Cypress Thriving, LA Who Am I to Love You?, Tessa DiPietro, " +
                "Happy, Paradise Is Very Fragile, Bare Feet on Linoleum, and many more. This beautiful hardcover edition showcases Lana’s typewritten manuscript pages alongside her original photography. " +
                "The result is an extraordinary poetic landscape that reflects the unguarded spirit of its creator.\r\n\r\nViolet Bent Backwards Over the Grass is also brought to life in an " +
                "unprecedented spoken word audiobook which features Lana Del Rey reading fourteen select poems from the book accompanied by music from Grammy Award–winning musician Jack Antonoff.", 435000, "../images/violet_bent.jpeg", "Lana Del Rey"),
           new Book(2, "Waging Heavy Peace: A Hippie Dream", "Neil Young is a singular figure in the history of rock and pop culture in the last four decades, inducted not once but twice into the Rock and Roll Hall of Fame.\r\n\r\nReflective, insightful and disarmingly honest, Waging Heavy Peace is his long-awaited memoir. From his youth in Canada to his crazy journey out to California, " +
                "through Buffalo Springfield and Crosby, Stills & Nash, to his massively successful solo career and his re-emergence as the patron saint of grunge on to his role today as one of the last uncompromised and uncompromising survivors of rock 'n' roll - this is Neil's story told in his own words.\r\n\r\nYoung presents a kaleidoscopic view of personal life and musical creativity;" +
                " it's a journey that spans the snows of Ontario to the LSD-laden boulevards of 1966 Los Angeles to the contemplative paradise of Hawaii today. Along the way he writes about the music, the victims, the girls and the drugs; about his happy family life but also about the health problems he and his children have experienced; about guitars, cars and sound systems;" +
                " about Canada and California and Hawaii. Candid, witty and revealing, this book takes its place beside the classic memoirs of Bob Dylan and Keith Richards.\r\n\r\n'Wryly funny, deeply moving, painfully honest' Guardian\r\n\r\n'He's talking to you, not at you, unravelling himself as well, and you don't want it to end . . . You see rock and roll history from the inside out, and in the present tense' " +
                "Independent\r\n\r\n'Young appears bounteous and joyful, a genuinely happy hippy . . . Unusually for a rock memoir, this one is almost completely angst-free' Sunday Times\r\n\r\n'Dryly hilarious . . . poignant . . . Waging Heavy Peace shows that Young is still in full possession of that stubborn, brilliant, one-of-a-kind instrument' Rolling Stone\r\n\r\n'A real treat . . . ", 129200, "../images/hipple.jpeg", "Neil Young"),
           new Book(3, "Is This Anything?", "Since his first performance at the legendary New York nightclub “Catch a Rising Star” as a twenty-one-year-old college student in fall of 1975, Jerry Seinfeld has written his own material and saved everything. “Whenever I came up with a funny bit, whether it happened on a stage, in a conversation, or working it out on my preferred canvas, " +
                "the big yellow legal pad, I kept it in one of those old school accordion folders,” Seinfeld writes. " +
                "“So I have everything I thought was worth saving from forty-five years of hacking away at this for all I was worth.”", 496850, "../images/ita.jpeg", "Jerry Seinfeld")];
            bookCount = bookList.Count;
        }

        public IActionResult Index()
        {
            if (bookList == null)
                listInitial();
            return View(bookList);
        }

        public IActionResult Delete(int id)
        {
            if (bookList != null)
            {
                Book? delBook = bookList.FirstOrDefault((e) => e.id == id);
                if (delBook != null)
                {
                    bookList.Remove(delBook);
                    bookCount--;
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Book());
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            book.id = ++bookCount;
            bookList!.Add(book);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Book? editBook = null;

            if (bookList != null)
            {
                editBook = bookList.FirstOrDefault(e => e.id == id);
            }

            if (editBook == null)
            {
                ViewBag.Message = "Book not found.";
            }

            return View(editBook);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {

         
            if (bookList != null)
            {
                foreach (Book editBook in bookList)
                {
                    if (editBook.id == book.id)
                    {
                        editBook.title = book.title;
                        editBook.description = book.description;
                        editBook.author = book.author;
                        editBook.price = book.price;
                    }
                }
            }
            return RedirectToAction("Index");

        }

    }
}
