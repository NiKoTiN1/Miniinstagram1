import { TestBed } from '@angular/core/testing';

import { ImageServices } from './image.services';

describe('UploadService', () => {
  let service: ImageServices;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImageServices);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
