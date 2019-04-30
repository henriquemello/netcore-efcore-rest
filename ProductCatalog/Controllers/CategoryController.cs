 using System.Collections.Generic;
 using System.Linq;
 using Microsoft.AspNetCore.Mvc;
 using Microsoft.EntityFrameworkCore;
 using ProductCatalog.Data;
 using ProductCatalog.Models;
using ProductCatalog.Repositories;

namespace ProductCatalog.Controllers{
     
     public class CategoryController : Controller{
         private readonly CategoryRepository _categoryRepository;
         public CategoryController(CategoryRepository categoryRepository){
             _categoryRepository = categoryRepository;
         }


        [Route("v1/categories")]
        [HttpGet]
        public IEnumerable<Category> Get(){
            return _categoryRepository.Get();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public Category Get(int id){
            return _categoryRepository.Get(id);
        }

        [Route("v1/categories/{id}/products")]
        [HttpGet]
        public IEnumerable<Product> GetProducts(int id){
            return _categoryRepository.GetProducts(id);
        }



        [Route("v1/categories")]
        [HttpPost]
        public Category Post([FromBody]Category category){
            
            return _categoryRepository.Save(category);
        }

        [Route("v1/categories")]
        [HttpPut]
        public Category Put([FromBody]Category category){
            
            return _categoryRepository.Update(category);
        }

        [Route("v1/categories")]
        [HttpDelete]
        public Category Delete([FromBody]Category category){
            
            return _categoryRepository.Remove(category);

        }

     }
 }