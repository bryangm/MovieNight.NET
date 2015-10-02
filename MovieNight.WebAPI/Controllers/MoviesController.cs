using MovieNight.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MongoDB.Bson;
using MovieNight.Domain.Entities;
using MongoDB.Driver;

namespace MovieNight.WebAPI.Controllers
{
    [RoutePrefix("api/movies")]
    public class MoviesController : ApiController
    {
        private readonly IMoviesRepository _repository;

        public MoviesController(IMoviesRepository repository)
        {
            _repository = repository;
        }

        #region Routes: movies
        [Route("")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetMovies()
        {
            HttpResponseMessage response;
            var results = await _repository.FindAllMovies();

            try
            {
                response = (results == null || results.Count == 0) 
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "No movies found") 
                    : Request.CreateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        [Route("")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostMovie(Movie movie)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.InsertMovie(movie);

                response = Request.CreateResponse(HttpStatusCode.Created, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        #endregion

        #region Routes: movies/{movieId}
        [Route("{movieId}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetMovie(string movieId)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.FindMovieById(movieId);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie not found")
                    : Request.CreateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        [Route("{movieId}")]
        [HttpPatch]
        public async Task<HttpResponseMessage> PatchMovie(string movieId, Movie movie)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.UpdateMovie(movieId, movie);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie not found")
                    : Request.CreateResponse(HttpStatusCode.Created, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        [Route("{movieId}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteMovie(string movieId)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.DeleteMovie(movieId);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie not found")
                    : Request.CreateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        #endregion

        #region Routes: movies/{movieId}/directors
        [Route("{movieId}/directors")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostDirector(string movieId, Person person)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.InsertDirector(movieId, person);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie not found")
                    : Request.CreateResponse(HttpStatusCode.Created, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        #endregion

        #region Routes: movies/{movieId}/directors/{personId}
        [Route("{movieId}/directors/{personId}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteDirector(string movieId, string personId)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.DeleteDirector(movieId, personId);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie not found")
                    : Request.CreateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        #endregion

        #region Routes: movies/{movieId}/writers
        [Route("{movieId}/writers")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostWriter(string movieId, Person person)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.InsertWriter(movieId, person);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie not found")
                    : Request.CreateResponse(HttpStatusCode.Created, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        #endregion

        #region Routes: movies/{movieId}/writers/{personId}
        [Route("{movieId}/writers/{personId}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteWriter(string movieId, string personId)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.DeleteWriter(movieId, personId);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie not found")
                    : Request.CreateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        #endregion

        #region Routes: movies/{movieId}/cast
        [Route("{movieId}/cast")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostCastMember(string movieId, Person person)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.InsertCastMember(movieId, person);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie not found")
                    : Request.CreateResponse(HttpStatusCode.Created, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        #endregion

        #region Routes: movies/{movieId}/cast/{personId}
        [Route("{movieId}/cast/{personId}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteCastMember(string movieId, string personId)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.DeleteCastMember(movieId, personId);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie not found")
                    : Request.CreateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        #endregion
    }
}